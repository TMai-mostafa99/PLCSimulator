using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : PLCComponent
{
    public SignalData Output;

    protected override void Start()
    {
        base.Start();
        Output = new SignalData(VarTypes.BOOL, "Output", false, 0, false);
        Data.Add(Output);
    }


}
