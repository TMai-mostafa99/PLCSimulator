using System;
using UnityEngine;

public class TON_timer : Timer
{

    
    //TODO: RESET ON SIGNAL CHANGE
    protected override void Start()
    {
        base.Start();

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        // Detect the transition from False to True
        if (!previousSignal  && IN.Signal)
        {
            startTime = Time.time;
            timerRunning = true;
        }
        if (timerRunning)
        {
            ET.Number = (int)(Time.time - startTime);

            if(ET.Number >= PT.Number)
            {
                Q.Signal = SignalOut = true;
                timerRunning = false;
            }
            else
            {
                Q.Signal = SignalOut = false;
            }
        }
        else
        {
            // If the timer is not running and input is True, keep the output ON
            if (!IN.Signal)
            {
                Q.Signal = SignalOut = false;
                ET.Number = 0;
            }
        }

        previousSignal = IN.Signal;
      
    }
}
