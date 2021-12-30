using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Popup for the timer
//Can be used for searching, building, etc
public class TimerPopup : Popup
{
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        //Ready to start the timer!
        timer.StartTimer();
        //Also show the timer popup
        this.ShowPopup();
    }

    public void TimerFinished()
    {
        ItemScript item = this.gameObject.GetComponentInParent<ItemScript>();
        bool showReadyPopUp = false;

        //Check to make sure item is a type that HAS a timer
        //i.e. Harvest, Build, or Search

        //If it is, set the variables to show that they're ready
        //Also set a boolean to show that we should popup the ReadyPopup
        switch (item.type)
        {
            case ItemType.HARVEST_ITEM:
                HarvestItemScript harvestItem = (HarvestItemScript)item;
                harvestItem.isComposted = true;
                showReadyPopUp = true;
                break;
            case ItemType.BUILD_ITEM:
                BuildItemScript buildItem = (BuildItemScript)item;
                buildItem.isBuilt = true;
                showReadyPopUp = true;
                break;
            case ItemType.SEARCH_ITEM:
                SearchItemScript searchItem = (SearchItemScript)item;
                searchItem.searched = true;
                searchItem.searching = false;
                showReadyPopUp = true;
                break;
        }

        if (showReadyPopUp)
        {
            GetComponentInParent<ReadyPopup>().Show();
            this.HidePopup();
        }
    }
}
