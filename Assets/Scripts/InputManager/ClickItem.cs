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
        //First we need to check the type
        //Only the specialized items have a click
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit2D hit2d = Physics2D.GetRayIntersection(ray);
        Collider2D[] results = Physics2D.OverlapPointAll(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));

        foreach (Collider2D collider in results)
        {
            Debug.Log("CI Collider name : " + collider.gameObject.name);
            if (collider.gameObject.tag == "ItemsObject")
            {
                //Ok, found the item we clicked on.
                //Now make sure it has the IClick interface - that way we can call the Click method
                collider.gameObject.TryGetComponent<IClick>(out IClick clickComponent);
                clickComponent?.Click();

                //if(clickComponent != null)
                //{
                //    clickComponent.Click();
                //}

            }
        }
    }
}
