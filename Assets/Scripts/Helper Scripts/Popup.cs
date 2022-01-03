using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPopup()
    {
        GetComponent<Renderer>().enabled = true;
    }

    public void HidePopup()
    {
        GetComponent<Renderer>().enabled = false;
    }
}
