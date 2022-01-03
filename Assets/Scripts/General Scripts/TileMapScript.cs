using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds the board and takes care of merging, creating, and generating items
public class TileMapScript : MonoBehaviour
{
    //public TileScript[] nonStaticTiles;
    public static TileScript[] tiles;
    
    // Start is called before the first frame update
    void Start()
    {
        //tiles = nonStaticTiles;
        GameObject[] allTiles = GameObject.FindGameObjectsWithTag("Tile");
        tiles = new TileScript[allTiles.Length];

        for(int i = 0; i < allTiles.Length; i++)
        {
            tiles[i] = allTiles[i].GetComponent<TileScript>();
        }

        //Temporary placement - for testing only
        CollectableItemInventoryScript.InitializeDictionaryFirstTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void GenerateItem(GameObject item)
    {
        GameObject newItem = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);
        newItem.transform.parent = GameObject.FindGameObjectWithTag("ItemsObject").transform;
        newItem.transform.localScale = new Vector3(1, 1, 1);
        PlaceItem(newItem.GetComponent<ItemScript>());
    }

    public static void SwapItem(ItemScript item1, ItemScript item2)
    {
        TileScript t1 = item1.tile;
        TileScript t2 = item2.tile;

        //Set up item2 on t1
        t1.item = item2;
        item2.tile = t1;
        item2.transform.position = t1.transform.position;

        //Set up item1 on t2
        t2.item = item1;
        item1.tile = t2;
        item1.transform.position = t2.transform.position;
    }

    public static void PlaceItem(ItemScript item)
    {
        //Find the first empty spot and drop the item there
        for (int i = 0; i < tiles.Length; i++)
        {
            if (!tiles[i].item)
            {
                tiles[i].item = item;
                item.transform.position = tiles[i].transform.position;
                item.tile = tiles[i];
                return;
            }
        }

        //If we got to here, there's no more empty space...
        //This should be caught in the "Create Item" Method
    }

    public static void CombineItems(List<TileScript> matchingTiles, ItemScript currentItem)
    {
        //Figure out how many items there are
        int numUpgrades = 0;
        int numRemaining = 0;

        //Check if there's less than 4 items in the list
        //(4 items + 1 hover = 5 matching items)
        if (matchingTiles.Count < 4)
        {
            numUpgrades = 1;
            numRemaining = matchingTiles.Count - 2; //Probably just 4
        }
        else
        {
            numUpgrades = (matchingTiles.Count + 1) / 5;
            numRemaining = (matchingTiles.Count + 1) % 5;

            if (numRemaining >= 3)
            {
                numUpgrades++;
                numRemaining -= 3;
            }
        }

        //Set the next item - just set the first x number of tiles in matching tiles
        //to have that item
        int tileIndex = 0;

        //Set upgrades
        while (numUpgrades > 0)
        {
            //Create the object from the prefab
            GameObject newItem = Instantiate(currentItem.nextItem, matchingTiles[tileIndex].transform.position, Quaternion.identity);
            newItem.transform.parent = GameObject.FindGameObjectWithTag("ItemsObject").transform;
            newItem.transform.localScale = new Vector3(1, 1, 1);
            ItemScript oldItem = matchingTiles[tileIndex].item;
            Destroy(oldItem.gameObject);
            matchingTiles[tileIndex].item = newItem.GetComponent<ItemScript>();
            newItem.GetComponent<ItemScript>().tile = matchingTiles[tileIndex];
            newItem.transform.position = matchingTiles[tileIndex].transform.position;
            tileIndex++;
            numUpgrades--;
        }

        //Keep any extra of the original items
        while (numRemaining > 0)
        {
            tileIndex++;
            numRemaining--;
        }

        //Now clear the rest of the tiles
        for (int i = tileIndex; i < matchingTiles.Count; i++)
        {
            Destroy(matchingTiles[i].item.gameObject);
            matchingTiles[i].item = null;
        }

        //Delete the current item
        Destroy(currentItem.gameObject);
    }

    //Check if we still have space
    //true = yes we have space
    public static bool HasSpace()
    {
        int countEmptyTiles = CountFreeSpaces();

        return countEmptyTiles > 3; //Default we need 3 free spaces on our board
    }



    public static int CountFreeSpaces()
    {
        int count = 0;

        foreach(TileScript t in tiles)
        {
            if (!t.item)
            {
                count++;
            }
        }

        return count;
    }
}
