using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSP_contact : Contact
{
    private bool previousSignalIn;

    void Update()
    {
        //// Check if there's a rising edge (false -> true transition)
        //    // Rising edge detected, set one-shot output to true

        //else
        //    // No rising edge, ensure output is false
        SignalOut.Signal = SignalIn.Signal && !previousSignalIn ? RungSignal.Signal : false;
        // Update previous state for next frame
        previousSignalIn = SignalIn.Signal;
    }
}