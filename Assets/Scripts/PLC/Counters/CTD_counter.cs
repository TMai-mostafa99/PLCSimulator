using UnityEngine;

public class CTD_counter : Counter
{
    protected override void Update()
    {
        base.Update();
        CD.Signal = SignalIn = RungSignal;
        if (LD.Signal)
        {
            CV.Number = PV.Number;
        }

        if (CV.Number <= 0 && CD.Signal) Q.Signal = SignalOut = true;
        else Q.Signal = SignalOut = false;

        if (CD.Signal && !previousSignalIn) CV.Number--;

        previousSignalIn = SignalIn;
    }

}
