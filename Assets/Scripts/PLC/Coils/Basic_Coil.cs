using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Coil : Coil
{
 
    protected override void Update()
    {
        base.Update();
        SignalOut = RungSignal;
        if (SignalOut.Signal)
        {
            Debug.Log("Signal out is true");
        }
    }
}
