using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTU_counter : Counter
{
    //--------------------------------//
    private bool previousSignalIn;
    public bool isSet; 
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        CU.Signal = SignalIn.Signal = RungSignal.Signal;

        if (CV.Number == PV.Number) Q.Signal = SignalOut.Signal = true;
        else Q.Signal = SignalOut.Signal = false;

        if (R.Signal) CV.Number = 0;

        //count on rising edge
        if (CU.Signal && !previousSignalIn) CV.Number++;

        previousSignalIn = SignalIn.Signal;

    }

    public void UnSetCTU_counter()
    {

    }
}
