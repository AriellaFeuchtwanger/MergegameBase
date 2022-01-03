using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Buildable items
//These are items that you have to build before they count as a real item
//TODO
//Add consideration for this in the TileMapScript
public class BuildItemScript : ItemScript, IClick
{
    public int energyRequired;
    public float secondsToComplete;
    public bool isBuilt;

    // Start is called before the first frame update
    void Start()
    {
        //This item has not been built yet - set it to be slightly transparent
        ChangeColor(200);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When this item is pressed, we want to show some sort of popup
    public void Click()
    {
        //Show a popup with a button

    }

    //Called after sufficient time has passed for the item to be built
    public void ItemBuilt()
    {
        //Bring the item back to full color!
        ChangeColor(255);
    }

    private void ChangeColor(int alpha)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color color = sr.color;
        color.a = alpha;
        sr.color = color;
    }
}
