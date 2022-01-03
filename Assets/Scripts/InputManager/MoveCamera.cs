using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCamera : MonoBehaviour
{
    private ActionsController controls;
    [SerializeField]
    private float mouseDragSpeed = 1f;
    [SerializeField]
    private Coroutine moveCoroutine;
    Transform cameraTransform;

    private void Start()
    {
        controls.Items.MoveCamera.started += MoveCameraAround;
        controls.Items.MoveCamera.canceled += _ => StopMoving();
    }

    private void Awake()
    {
        controls = new ActionsController();
        cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        Debug.Log("MC - Attached!");
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
        
    }

    private void MoveCameraAround(InputAction.CallbackContext context)
    {
        Debug.Log("MC - Starting to move!");
        moveCoroutine = StartCoroutine(Move());
    }

    private void StopMoving()
    {
        Debug.Log("MC - Stopping");
        StopCoroutine(moveCoroutine);
    }

    IEnumerator Move()
    {
        //First let's check if there's a big enough difference in position.
        
        Vector3 targetPosition = cameraTransform.position;
        Vector3 previousLocation = targetPosition;
        while (true)
        {
            ////Get the current mouse position
            Vector2 position = Camera.main.ScreenToWorldPoint(controls.Items.PrimaryFingerPosition.ReadValue<Vector2>());

            //Figure out what direction we're moving in
            if (previousLocation.x < position.x)
            {
                targetPosition.x = previousLocation.x + .25f;
            }
            else if (previousLocation.x > position.x)
            {
                targetPosition.x = previousLocation.x - .25f;
            }

            if (previousLocation.y < position.y)
            {
                targetPosition.y = previousLocation.y+ .25f;
            }
            else if (previousLocation.y > position.y)
            {
                targetPosition.y = previousLocation.y- .25f;

            }
            //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(controls.Items.PrimaryFingerPosition.ReadValue<Vector2>());
            Debug.Log("MC - Mouse Position: " + position.x + ", " + position.y);
            Debug.Log("MC - Camera Position: " + cameraTransform.position.x + ", " + cameraTransform.position.y);
            //cameraTransform.position = Vector3.Slerp(cameraTransform.position,
            //    targetPosition, Time.deltaTime * mouseDragSpeed);
            cameraTransform.position = targetPosition;
            previousLocation = targetPosition;
            yield return new WaitForSeconds(.025f);
            //yield return null;
        }
    }
}
