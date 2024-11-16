using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOF_timer : Timer
{

    protected override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(previousSignal && !IN.Signal)
        {
            startTime = Time.time;
            timerRunning = true;
        }

        if (timerRunning)
        {
            ET.Number = (int)(Time.time - startTime);

            // Check if elapsed time has reached the preset time
            if (ET.Number >= PT.Number)
            {
                Q.Signal = SignalOut = false; // Turn OFF the output
                timerRunning = false;        // Stop the timer
            }
            else
            {
                Q.Signal = SignalOut = true; // Keep the output ON during the delay
            }
        }
        else
        {
            // If the timer is not running and input is True, keep the output ON
            if (IN.Signal)
            {
                Q.Signal = SignalOut = true;
                ET.Number = 0; // Reset elapsed time
            }
        }

        // Update the previous signal state
        previousSignal = IN.Signal;
    }

}

