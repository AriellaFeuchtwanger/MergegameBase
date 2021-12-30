using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using static UnityEngine.InputSystem.InputAction;

//Base script for all items
public class ItemScript : MonoBehaviour, IDrag
{
     //BaseItem values
    public GameObject nextItem;
    public ItemType type;
    public bool finalMerge;
    public int mergeXP;
    public int itemLevel;
    public bool isMergeable;
    public bool isMoveable;
    public string itemName;

    public TileScript tile;
    //Images Sprites
    public Sprite regImage;
    public Sprite glowImage;

    public Vector2 prevPosition;
    private bool isGlowing;

    //Values for the action stuff
    //public PlayerInput playerInput;
    [SerializeField]
    private float dragSpeed = 0f;
    [SerializeField]
    private Vector3 velocity = Vector3.zero;
    Camera mainCamera;
    private bool attached = false;
    //[SerializeField]
    //private InputAction dragAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        //Debug.Log("awake!");
        mainCamera = Camera.main;
        //playerInput.onActionTriggered += SortActions;
    }

    private void OnEnable()
    {
        //Debug.Log("enabled1");
        //playerInput.actionEvents.Enable();
        //playerInput.onActionTriggered += context =>
        //{
        //    Debug.Log(context.action.name);
        //    if(context.action.name == "Drag")
        //    {

        //        SortActions(context);
        //    }
        //};
        
    }

    
    public void OnStartDrag()
    {
        //When we start dragging the guy around, we want to...
        //Track the previous position
        Debug.Log("IS - Starting to drag");
        this.prevPosition = transform.position;
        //Set its tile item to null
        tile.item = null;
        //Change to the right sprite
        SetGlow();
    }

    public void OnEndDrag(Vector3 location)
    {
        Debug.Log("IS = " + itemName + ": I have been dropped...");
        //Drop the item on a tile, then check the tile
        //if(context.valueType is Vector2)
        //{
        //    Debug.Log("Correct type!");
        //}
        //else
        //{
        //    Debug.Log("Incorrect type!");
        //    return;
        //}
        Collider2D[] results = Physics2D.OverlapPointAll(location);
        Debug.Log("IS - You found " + results.Length + " tiles.");
        TileScript currentTile = GetTile(results);

        if (currentTile == null)
        {
            //The item is hovering somewhere where there are no tiles, so let's put it back where it started
            Debug.Log("IS - Did not find a tile :(");
            SetGlow();
            transform.position = prevPosition;
            tile.item = this;
        }
        //} else if (currentTile.item != null && !currentTile.item.item.isMoveable)
        //{
        //    //There's something in the way. Go back to where you came from!
        //    Debug.Log("YOU SHALL NOT DROP");
        //    SetGlow();
        //    transform.position = prevPosition;
        //}
        else
        {
            //Ok, got a good tile! Let's check for a merge/move
            Debug.Log("IS - Move me! Move me!");
            SetGlow();
            currentTile.DropItem(this);
        }
    }

    TileScript GetTile(Collider2D[] results)
    {
        TileScript currentTile = null;
        foreach (Collider2D col in results)
        {
            if(col.gameObject.tag == "Tile")
            {
                currentTile = col.gameObject.GetComponent<TileScript>();
                Debug.Log("IS - Tile name: " + currentTile.name);
            }
        }

        return currentTile;
    }

    private void SetGlow()
    {
        if (isGlowing)
        {
            isGlowing = false;
            GetComponent<SpriteRenderer>().sprite = regImage;
        }
        else
        {
            isGlowing = true;
            GetComponent<SpriteRenderer>().sprite = glowImage;
        }
    }

    
}
