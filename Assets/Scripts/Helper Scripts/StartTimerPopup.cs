using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Show the popup to start the timer
//Applies to any object that requires a timer - such as a build or search item
public class StartTimerPopup : Popup
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        //When the button is clicked...
        //Hide the popup
        this.HidePopup();
        //Show the TimerPopup
        TimerPopup tPop = this.gameObject.GetComponentInParent<TimerPopup>();
        //tPop.ShowPopup();
        tPop.StartTimer();
    }
}
