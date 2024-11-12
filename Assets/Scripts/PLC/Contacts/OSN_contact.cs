using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSN_contact : Contact
{
    private bool previousSignalIn;

    protected override void Update()
    {
        base.Update();
     
        // Check if there's a falling edge (true -> false transition)
        SignalOut = !SignalIn && previousSignalIn ? RungSignal : false;
        // Update previous state for next frame
        previousSignalIn = SignalIn;
    }
}
