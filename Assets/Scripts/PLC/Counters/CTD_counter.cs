using UnityEngine;

public class CTD_counter : Counter
{

    private bool initialize = false;
    protected override void Update()
    {
        base.Update();
        CD.Signal = SignalIn = RungSignal;
        if(CD.Signal && !initialize)
        {
            CV.Number = PV.Number;
            initialize = true;
        }
        if (CV.Number <= 0 && CD.Signal) Q.Signal = SignalOut = true;
        else Q.Signal = SignalOut = false;

        if (CD.Signal && !previousSignalIn && !LD.Signal) CV.Number--;

        previousSignalIn = SignalIn;
    }

}
