using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for each tile on the board

public class TileScript : MonoBehaviour
{
    public TileScript[] tiles = new TileScript[4]; //left, top, right, bottom
    public ItemScript item;
    public Sprite regTile;
    public Sprite glowTile;
    public bool isVisible;
    private bool isGlowing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropItem(ItemScript item)
    {
        Debug.Log("TS - Time to drop the item " + item.itemName);
        //First check if there's anything on this tile
        //If not, just drop the item
        if(this.item == null || !this.item)
        {
            Debug.Log("TS - We did not find an item on tile " + this.name);
            this.item = item;
            item.tile = this;
            item.transform.position = this.transform.position;
            return;
        }
        Debug.Log("TS - Item name: " + this.item.itemName);
        Debug.Log("TS - Tile name: " + this.name);

        //Check if we're dropping the item on the same item
        //If not, just place the item (use the MainGameScript)
        if (!this.item.itemName.Equals(item.itemName))
        {
            Debug.Log("TS - There's something here already! Let's move it.");
            //The item being dragged is not the same as the item on this tile
            //Put this item down and move the previous item elsewhere
            TileMapScript.SwapItem(this.item, item);

            //Check if this is a moveable item.
            //if (!this.item.item.isMoveable)
            //{
            //    //If not, place the item anywhere
            //    TileMapScript.PlaceItem(item);
            //} else
            //{
            //    //If yes, swap locations
            //    TileMapScript.SwapItem(this.item, item);

            //}
            return;
        }

        //Now check that you CAN merge the item
        if (!item.nextItem)
        {
            Debug.Log("TS - This is the end of the evolution. Do not combine");
            //If you can't (i.e. it's the end of the evolution)
            //Swap 'em
            TileMapScript.SwapItem(this.item, item);
            return;
        }

        //If we get to this point, we have an item hovering over a tile with the same item
        //the item is moveable, and we still have combos to make
        //Get a list of all tiles with the same item
        Debug.Log("TS - It's matching time!!");
        List<TileScript> matchingTiles = GetTileList(item);

        //Check if we even have enough items to move on
        //(2 in the list at least + 1 in hand
        if (matchingTiles.Count > 1)
        {
            print("TS - Matching tiles count: " + matchingTiles.Count);
            TileMapScript.CombineItems(matchingTiles, item);
        }
        else
        {
            //Put this item down and move the previous item elsewhere
            TileMapScript.SwapItem(this.item, item);
        }

    }

    public List<TileScript> GetTileList(ItemScript item)
    {
        bool keepGoing = true;
        List<TileScript> matchingTiles = new List<TileScript>();
        int index = 0;

        //Add the current tile to the list (we only get here if it belongs in the list)
        matchingTiles.Add(this);

        Debug.Log("TS - beginning the loop");
        while (keepGoing)
        {
            //Check each tile
            //If contains same item, add to List
            //Otherwise, just continue
            //If the index = length of list, exit
            for (int i = 0; i < 4; i++)
            {
                if (CheckTile(matchingTiles[index].tiles[i]) && !matchingTiles.Contains(matchingTiles[index].tiles[i]))
                {
                    Debug.Log("TS - Adding tile " + this.name);
                    matchingTiles.Add(matchingTiles[index].tiles[i]);
                }
            }

            index++;

            if (index == matchingTiles.Count)
            {
                Debug.Log("TS - I have found the end!");
                keepGoing = false;
            } else if(index == 10)
            {
                Debug.Log("TS - We defaulted...:(");
                keepGoing = false;
            }
        }

        return matchingTiles;
    }

    public bool CheckTile(TileScript currTile)
    {
        //Debug.Log("Checking tile " + currTile.name);
        if(currTile && currTile.item && currTile.item.itemName.Equals(this.item.itemName))
        {
            Debug.Log("TS - We are the same!");
            return true;
        }
        else
        {
            if(currTile && currTile.item)
            {
                Debug.Log("TS - We are not the same. Equals result: " + currTile.item.itemName.Equals(this.item.itemName));
            }
            
            return false;
        }
    }

    public void SetGlow()
    {
        if (isGlowing)
        {
            isGlowing = false;
            GetComponent<SpriteRenderer>().sprite = regTile;
        }
        else
        {
            isGlowing = true;
            GetComponent<SpriteRenderer>().sprite = glowTile;
        }
    }
}
