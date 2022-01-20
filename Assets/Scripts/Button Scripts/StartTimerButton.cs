using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimerButton : MonoBehaviour, IClick
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        //When the button is clicked...
        //Hide the popup
        this.gameObject.GetComponentInParent<StartTimerPopup>().HidePopup();
        //Show the TimerPopup
        TimerPopup tPop = this.gameObject.GetComponentInParent<TimerPopup>();
        //tPop.ShowPopup();
        tPop.StartTimer();
    }
}
