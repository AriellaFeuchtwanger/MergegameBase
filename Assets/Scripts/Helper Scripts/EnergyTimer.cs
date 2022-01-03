using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Timer for regenerating energy
public class EnergyTimer : MonoBehaviour
{
    public float timeRemaining = 180;
    public bool timerIsRunning = false;
    public Text timeText;

    void Start()
    {

    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("ET - Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                //Add 1 to the energy
                EnergyTracker.energy += 1;
            }
        }
    }

    public void StartTimer()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timeRemaining = 180;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
