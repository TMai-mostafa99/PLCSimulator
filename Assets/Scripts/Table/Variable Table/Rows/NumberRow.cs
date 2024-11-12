using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class NumberRow : TableRow
{
    public TMP_InputField input;
   
   // private int _value;
    public Action<int> OnValueChanged;
    public int Value;


    protected override void Update()//maybe not in update
    {
        base.Update();
        if (input.text == string.Empty)
            input.text = "0";
        if (AssignedSignals.Count != 0) 
        {
            foreach(PLCComponent.SignalData signal in AssignedSignals)
            {
                input.text = signal.SetNumber(int.Parse(input.text), this).ToString();
            }
        } 
        Value = int.Parse(input.text);
    }
}
