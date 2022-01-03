using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Popup for when an item is ready for collection
public class ReadyPopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        GetComponent<Renderer>().enabled = true;
    }

    public void Hide()
    {
        GetComponent<Renderer>().enabled = false;
    }
}
