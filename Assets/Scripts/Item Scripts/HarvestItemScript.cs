using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//TODO - Implement the start composting and speed up composting popups
//This class is for items  you can search and then will generate new items
//It generates a CollectableResourceItemScript - between 4-6 of them
public class HarvestItemScript : ItemScript, IClick
{
    public CollectableResourceItemScript collectableItem;
    public int maxTimesToHarvest;
    public Sprite deadSpriteImage;
    public ItemScript[] itemsPostComposting;
    public bool isComposted = false;
    public bool isHarvestable = true;

    private int timesHarvested;
    private int numResourcesRemaining;
    private bool clicked = false;
    private List<ItemScript> itemsYouGotComposting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //On click - we want to get the collectable item OR give the option to remove
    //In my games, removal = time, not energy
    public void Click()
    {
        Debug.Log("HIS - We have been clicked on!");
        //Check if this is a dead item
        if (timesHarvested == maxTimesToHarvest)
        {
            //Check if we already composted
            if (isComposted)
            {
                //Ok, so we're already in the "get the items" phase
                //Check if we have remaining gifts we're supposed to get
                if (clicked)
                {
                    //Try to place the items again
                    bool compost2Success = PlaceGeneratedItems();

                    if (compost2Success)
                    {
                        //Destroy the object
                        this.tile.item = null;
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    //Mark item as clicked once (i.e., items generated)
                    clicked = true;

                    //Generate the composted items
                    GenerateCompostItems();

                    //Try to place the items
                    bool compostSuccess = PlaceGeneratedItems();

                    if (compostSuccess)
                    {
                        //Destroy the object
                        this.tile.item = null;
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        //Show the popup that something is still here
                    }
                }
            }
            else
            {
                Debug.Log("HIS - We should be composting");
                //Check if the popup is already up

                //If it's already up, give the offer to speed up

                //If it's not, bring it up
            }

            return;
        }

        //Check if we tried harvesting but there wasn't enough room
        if (clicked)
        {
            if (TileMapScript.HasSpace())
            {
                //Try harvesting again
                CheckSuccess(PlaceItems());

            }
            return;
        }

        //Check if we can harvest. If not, give the option to speed up
        if (!isHarvestable)
        {
            //Ask to speed up/Show speedup popup

            return;
        }

        //Mark as having clicked item
        clicked = true;

        //Get a random number of resources between 4 and 6
        numResourcesRemaining = Random.Range(4, 7);

        //Try to put them on the board
        CheckSuccess(PlaceItems());
    }

    public void Composted()
    {

    }

    private bool PlaceItems()
    {
        bool full = false;
        while(numResourcesRemaining > 0 && !full)
        {
            if (TileMapScript.HasSpace())
            {
                TileMapScript.GenerateItem(collectableItem.gameObject);
                numResourcesRemaining--;
            }
            else
            {
                full = true;
            }
        }

        if (full)
        {
            //Put a marker on the item to show there's still more to harvest
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool PlaceGeneratedItems()
    {
        bool full = false;

        foreach (ItemScript item in itemsYouGotComposting)
        {
            if (TileMapScript.HasSpace())
            {
                TileMapScript.GenerateItem(item.gameObject);
            }
            else
            {
                //There is no more room. Mark that and break out.
                full = true;
            }
        }

        if (full)
        {
            //Do something farther up.
            //Also put a marker on the item to show that it's still here
        }
        return !full;
    }

    private void CheckSuccess(bool success)
    {
        if (success)
        {
            //Successfully placed items, increase number of times harvested
            timesHarvested++;

            //Check if the item is fully harvested
            if (timesHarvested == maxTimesToHarvest)
            {
                GetComponent<SpriteRenderer>().sprite = deadSpriteImage;
                clicked = false;
            }
            else
            {
                //Reset the harvest timer
            }
        }
    }

    private void GenerateCompostItems()
    {
        //Get a random number between 4 and 6
        int numItems = Random.Range(4, 7);

        //Set up that list of items we get
        this.itemsYouGotComposting = new List<ItemScript>();

        for (int i = 0; i <= numItems; i++)
        {
            itemsYouGotComposting.Add(itemsPostComposting[Random.Range(0, itemsPostComposting.Length)]);
        }
    }
}
