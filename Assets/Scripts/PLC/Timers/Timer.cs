using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : PLCComponent
{
    public bool IN;
    public bool Q;

    public int PT;
    public int ET;
    public bool R;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        IN = SignalIn = RungSignal;
        if (R) ET = 0; //reset bit
    }
}
