using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


//TODO: Add a camera follow element
public class DragNDrop : MonoBehaviour
{
    [SerializeField]
    private InputAction dragAction;
    [SerializeField]
    private float mouseDragSpeed = 0f;
    [SerializeField]
    private Vector3 velocity = Vector3.zero;
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;

    }

    private void OnEnable()
    {
        dragAction.Enable();
        dragAction.performed += MousePressed;
    }

    private void OnDisable()
    {
        dragAction.performed -= MousePressed;
        dragAction.Disable();
    }

    private void MousePressed(InputAction.CallbackContext context)
    {
        Debug.Log("DND - Phase equals " + context.phase);
        Debug.Log("DND - You have clicked!");
        //StartCoroutine(DragItem(this.gameObject));
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit2D hit2d = Physics2D.GetRayIntersection(ray);
        Collider2D[] results = Physics2D.OverlapPointAll(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));

        foreach (Collider2D collider in results)
        {
            Debug.Log("DND Collider name : " + collider.gameObject.name);
            if (collider.gameObject.tag == "ItemsObject")
            {
                //currentObj = collider.gameObject;
                Debug.Log("DND - Starting the coroutine");
                StartCoroutine(DragItem(collider.gameObject));
                break;
            }
        }
    }

    private IEnumerator DragItem(GameObject obj)
    {
        Debug.Log("DND - Dragging!");
        float initialPosition = Vector3.Distance(obj.transform.position, mainCamera.transform.position);
        obj.TryGetComponent<IDrag>(out var iDragComponent);
        iDragComponent?.OnStartDrag();
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        while (dragAction.ReadValue<float>() != 0)
        {
            //Collider2D[] results = Physics2D.OverlapPointAll(Mouse.current.position.ReadValue());

            ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            obj.transform.position = Vector3.SmoothDamp(obj.transform.position, ray.GetPoint(initialPosition),
                ref velocity, mouseDragSpeed);
            yield return null;
        }
        Debug.Log("DND - Finished Loop");
        iDragComponent?.OnEndDrag(ray.GetPoint(initialPosition));

    }

}
