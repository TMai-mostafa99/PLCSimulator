using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEQ_comp : Compare
{
    protected override void Update()
    {
        base.Update();
        SignalOut = (NUM1.Number != NUM2.Number) && RungSignal ? true : false;
    }
}
