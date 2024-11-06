using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTU_counter : Counter
{
    //--------------------------------//
    private bool previousSignalIn;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        CU = SignalIn = RungSignal;

        if (CV == PV) Q = SignalOut = true;
        else Q = SignalOut = false;

        if (R) CV = 0;

        //count on rising edge
        if (CU && !previousSignalIn) CV++;

        previousSignalIn = SignalIn;

    }
}
