using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Coil : Coil
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        SignalOut = RungSignal;
        Output.Signal = SignalOut; // can't be changed from outside but can only be viewed
        if (SignalOut)
        {
            Debug.Log("Signal out is true");
        }
    }
}
