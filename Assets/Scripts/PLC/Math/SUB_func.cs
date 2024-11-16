using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUB_func : MathFunc
{
    protected override void Update()
    {
        base.Update();
        if (EN.Signal && !previousSignal) OUT.Number = Num1.Number - Num2.Number;
        previousSignal = SignalIn;
    }
}
