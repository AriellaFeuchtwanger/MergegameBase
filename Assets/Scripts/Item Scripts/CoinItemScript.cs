using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Special class for coin items
//These items are both collectable AND mergeable
//But before we collect, we want to make sure we really do want to collect
public class CoinItemScript : ItemScript, IClick
{
    public int numCoins;
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
            CoinTracker.AddCoins(numCoins);

            //Now that we've picked up the gems, time to destroy the item!
            this.tile.item = null;
            Destroy(this.gameObject);
        }
        else
        {
            //Otherwise, just register that it's clicked
            clicked = true;
            //Show confirmation popup
        }
    }
}
