using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickItem : MonoBehaviour
{
    [SerializeField]
    private InputAction clickAction;
    private Camera mainCamera;

    private void Awake()
    {
        this.mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        Debug.Log("CI - Attached!");
        clickAction.Enable();
        clickAction.started += MousePressed;
    }

    private void OnDisable()
    {
        clickAction.started -= MousePressed;
        clickAction.Disable();
    }

    private void MousePressed(InputAction.CallbackContext context)
    {
        

        //First let's see what's beneath the click - First we need to see if there's a button
        //then we'll check for buttons
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit2D hit2d = Physics2D.GetRayIntersection(ray);
        Collider2D[] results = Physics2D.OverlapPointAll(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));

        //Set up the different tags:
        bool itemTag = false;
        bool buttonTag = false;
        Collider2D itemCollider = new Collider2D();
        Collider2D buttonCollider = new Collider2D();

        //Now let's see what tags we have
        foreach (Collider2D collider in results)
        {
            Debug.Log("CI Collider name : " + collider.gameObject.name);
            if (collider.gameObject.tag == "ItemsObject")
            {
                itemTag = true;
                itemCollider = collider;

            }

            if(collider.gameObject.tag == "Button")
            {
                buttonTag = true;
                buttonCollider = collider;
            }
        }

        //Ok, found some colliders (hopefully). Now let's check the tags
        //If we found a buttonTag, that gets priority
        if (buttonTag)
        {
            buttonCollider.gameObject.TryGetComponent<IClick>(out IClick clickComponent);
            clickComponent?.Click();
        } else if (itemTag)
        {
            itemCollider.gameObject.TryGetComponent<IClick>(out IClick clickComponent);
            clickComponent?.Click();
        }
    }
}
