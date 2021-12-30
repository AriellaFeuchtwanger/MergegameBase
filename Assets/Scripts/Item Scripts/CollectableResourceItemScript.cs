using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//These are items that can be collected (such as milk, etc.)
//When collected, they go into the CollectableResourceInventory
public class CollectableResourceItemScript : ItemScript, IClick
{
    public CollectibleResourceType resourceType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //If clicked, add the item to the inventory
    public void Click()
    {
        Debug.Log("CRIS - We have been clicked!");
        CollectableItemInventoryScript.AddResource(this.resourceType, 1);
        this.tile.item = null;
        Destroy(this.gameObject);
    }
}
