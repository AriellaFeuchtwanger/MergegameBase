using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTracker : MonoBehaviour
{
    public static int energy;
    public static int maxEnergy;
    public static  EnergyTimer timer;

    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //Check if energy is not full AND that the timer is not running
        if(energy < maxEnergy && !timer.timerIsRunning)
        {
            //If not, then let's restart it
            timer.StartTimer();
        }
    }
}
