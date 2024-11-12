using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoolRow : TableRow
{
    public Toggle togglebool;
 //   public bool isWrite;
    public bool Value;


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (AssignedSignals.Count != 0)
        {
            foreach (PLCComponent.SignalData signal in AssignedSignals)
            {
                togglebool.isOn = signal.SetBool(togglebool.isOn, this); 
            }
        }
        Value = togglebool.isOn;
    }

}
