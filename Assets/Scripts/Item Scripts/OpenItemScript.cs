using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//This item opens up when clicked and generates a bunch of items
public class OpenItemScript : ItemScript, IClick
{
    public ItemScript[] itemsToGet;
    public int minNumberOfItems;
    public int maxNumberOfItems;

    private List<ItemScript> itemsYouGot;
    private bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //"Open" the item, create items, and remove this item
    public void Click()
    {
        //First, check if "clicked" is true
        if (clicked)
        {
            //Means we already clicked, but wasn't enough room
            //Let's check if we have space to put the items
            if (TileMapScript.HasSpace())
            {
                //If yes, let's start placing items
                bool success2 = PlaceItems(); //we return true if the board was not full

                //If we successfully placed all our items, destroy this item
                if (success2)
                {
                    //Finally, let's destroy this item so that the board has 1 less item
                    this.tile.item = null;
                    Destroy(this.gameObject);
                }

                //Otherwise, we want to keep the item around until it's empty
            }
            else
            {
                //Do something to show we don't have space!
            }
            return;
        }

        //Assuming we got here, that means this is the first time this object has been clicked.
        //Let's document that
        clicked = true;

        //Now, create the list of items this box has
        GenerateItems();

        //Then add them to the board...
        bool success = PlaceItems(); //we return true if the board was not full

        //If we successfully placed all our items, destroy this item
        if (success)
        {
            //Finally, let's destroy this item so that the board has 1 less item
            this.tile.item = null;
            Destroy(this.gameObject);
        }

        //Otherwise, we want to keep the item around until it's empty
    }

    public void GenerateItems()
    {
        //Get a random number between min and max
        System.Random rand = new System.Random();
        int numGifts = rand.Next(minNumberOfItems, maxNumberOfItems);

        //Set up that list of items we get
        this.itemsYouGot = new List<ItemScript>();

        for (int i = 0; i <= numGifts; i++)
        {
            itemsYouGot.Add(itemsToGet[rand.Next(itemsToGet.Length)]);
        }
    }

    private bool PlaceItems()
    {
        bool full = false;

        foreach(ItemScript item in itemsYouGot)
        {
            if (TileMapScript.HasSpace())
            {
                TileMapScript.PlaceItem(item);
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

}
