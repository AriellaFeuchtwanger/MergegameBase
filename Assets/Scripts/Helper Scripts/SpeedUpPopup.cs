using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Popup to speed up building/collecting etc.
public class SpeedUpPopup : MonoBehaviour
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
