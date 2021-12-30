using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Special class for gem objects
//These objects are mergeable AND collectable
//We want to make sure you want to collect it before you do, though
public class GemItemScript : ItemScript, IClick
{
    public int numGems;
    private bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        //First check if we've already clicked - so this is the confirmation
        //that yes, we want to pick it up
        if (clicked)
        {
            GemTracker.AddGems(numGems);

            //Now that we've picked up the gems, time to destroy the item!
            this.tile.item = null;
            Destroy(this.gameObject);
        }
        else
        {
            clicked = true;
            //Show confirmation popup
            GetComponent<ConfirmationPopup>().ShowPopup();
        }
    }
}
