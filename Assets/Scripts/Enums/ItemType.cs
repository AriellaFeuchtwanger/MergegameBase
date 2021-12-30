using System;
public enum ItemType
{
    OPEN_ITEM, //Click the item and get other items/collectable resources
    BASE_ITEM, //General, classic mergeable item
    HARVEST_ITEM, //Click on the item to get 4-6 collectable resources
    BUILD_ITEM, //Spend energy to build this item
    NON_MERGE_ITEM, //This item cannot be merged. It might require energy
    SEARCH_ITEM, //Use energy to search this item for other items/collectable resources
    IMMOVEABLE_ITEM, //This item cannot be moved
    COLLECTABLE_RESOURCE_ITEM //This item can be collected and moved, but is not mergeable
};