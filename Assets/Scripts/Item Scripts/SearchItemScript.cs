using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This item can be searched
//Once it's been searched, it will generate a number of random items (from itemsToGet)
public class SearchItemScript : ItemScript, IClick
{
    public ItemScript[] itemsToGet;
    public int maxItems;
    public int minItems;
    public bool searching = false;
    public bool searched = false;
    public int numSearchTimes;
    
    private List<ItemScript> itemsYouGot;
    private bool clicked = false;
    private int numTimesSearched = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When this item is clicked...
    //1. If we're not already searching, give the option to search
    //2. If we are searching, give the option to speed up
    //3. If we're done searching, generate gifts and try to place them
    public void Click()
    {
        if (this.searching)
        {
            //We are currently searching...want to speed up?
            //Hide the timer popup

            //Show the speed-up popup

        }
        else if (this.searched)
        {
            //We have finished searching...generate the items and place
            //(or finish placing, if the board was previously full)
            if (clicked)
            {
                //This was previously clicked; the board was full and we couldn't place the items
                if (TileMapScript.HasSpace())
                {
                    //If yes, let's start placing items
                    bool success2 = PlaceItems(); //we return true if the board was not full

                    //If we successfully placed all our items, destroy this item
                    if (success2)
                    {
                        //Now let's see if we need to evolve the object
                        if (numTimesSearched == numSearchTimes)
                        {
                            //Evolve
                        }
                    }

                    //Otherwise, we want to keep the item around until it's empty
                }
                else
                {
                    //Do something to show we don't have space!
                }
            }
            else
            {
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
                    //Now let's see if we need to evolve the object
                    if (numTimesSearched == numSearchTimes)
                    {
                        //Evolve
                    }
                }
            }
        }
        else
        {
            //This is the first time we've clicked - give the option to search
            //Show the search popup
            Debug.Log("SIS - Clicked, starting to search");
            this.GetComponentInChildren<StartTimerPopup>().ShowPopup();
        }
    }

    public void GenerateItems()
    {
        //Get a random number between min and max
        System.Random rand = new System.Random();
        int numGifts = rand.Next(minItems, maxItems);

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

        foreach (ItemScript item in itemsYouGot)
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
