using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inventory for collectable items
public class CollectableItemInventoryScript : MonoBehaviour
{
    public static Dictionary<CollectibleResourceType, Int64> collectables = new Dictionary<CollectibleResourceType, Int64>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void InitializeDictionaryFirstTime()
    {
        foreach(CollectibleResourceType crType in Enum.GetValues(typeof(CollectibleResourceType)))
        {
            collectables.Add(crType, 0); 
        }

    }

    public static void InitializeDictionaryOnGameLoad()
    {
        //Loop over each key-value pair and update the number
    }

    public static void AddResource(CollectibleResourceType type, Int64 number)
    {
        collectables[type] += number;
        Debug.Log(collectables[type]);
    }

    public static void RemoveResource(CollectibleResourceType type, Int64 number)
    {
        collectables[type] -= number;
    }

    public static Int64 GetCountOfResource(CollectibleResourceType type)
    {
        return collectables[type];
    }
}
