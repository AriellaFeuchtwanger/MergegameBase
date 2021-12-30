using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    private ActionsController controls;
    private Coroutine zoomCoroutine;
    private Transform cameraTransform;
    [SerializeField]
    private float speed = 4f;

    private void Awake()
    {
        controls = new ActionsController();
        cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Items.SecondaryTouchContact.started += _ => ZoomStart();
        controls.Items.SecondaryTouchContact.canceled += _ => ZoomEnd();
    }

    private void ZoomStart()
    {
        zoomCoroutine = StartCoroutine("ZoomDetection");
    }

    private void ZoomEnd()
    {
        StopCoroutine(zoomCoroutine);
    }

    IEnumerator ZoomDetection()
    {
        float previousDistance = 0f, distance = 0f;

        while (true)
        {
            //Get the distance between the fingers
            distance = Vector2.Distance(controls.Items.PrimaryFingerPosition.ReadValue<Vector2>(),
                controls.Items.SecondaryFingerPosition.ReadValue<Vector2>());

            //Detect if we're zooming
            if(distance > previousDistance)
            {
                //Zooming out
                Vector3 targetPosition = cameraTransform.position;
                targetPosition.z -= 1;
                Camera.main.orthographicSize--;
                //Camera.main.orthographicSize = Vector3.Slerp()
                //cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPosition, Time.deltaTime * speed);
            } else if(distance < previousDistance)
            {
                //Zooming in
                Vector3 targetPosition = cameraTransform.position;
                Camera.main.orthographicSize++;
                //targetPosition.z += 1;
                //cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPosition, Time.deltaTime * speed);
            }
            //Keep track of previous distance for next loop
            previousDistance = distance;
            yield return null;
        }
    }
}
