using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTU_counter : Counter
{


    // Start is called before the first frame update

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CU.Signal = SignalIn = RungSignal;

        if (CV.Number == PV.Number) Q.Signal = SignalOut = true;
        else Q.Signal = SignalOut = false;

        if (R.Signal) CV.Number = 0;

        //count on rising edge
        if (CU.Signal && !previousSignalIn) CV.Number++;

        previousSignalIn = SignalIn;

    }
}
