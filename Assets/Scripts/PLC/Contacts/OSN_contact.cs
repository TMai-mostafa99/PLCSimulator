using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSN_contact : Contact
{
    private bool previousSignalIn;

    void Update()
    {
        // Check if there's a falling edge (true -> false transition)
        SignalOut.Signal = !SignalIn.Signal && previousSignalIn ? RungSignal.Signal : false;
        // Update previous state for next frame
        previousSignalIn = SignalIn.Signal;
    }
}
