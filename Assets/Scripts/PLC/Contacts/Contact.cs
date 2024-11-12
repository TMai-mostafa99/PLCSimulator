using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : PLCComponent
{
    public SignalData Input;

    protected override void Start()
    {
        base.Start();
        Input = new SignalData(VarTypes.BOOL, "Input", false, 0, true);
        Data.Add(Input);
    }

    protected override void Update()
    {
        base.Update();
        SignalIn = Input.Signal;
    }
}
