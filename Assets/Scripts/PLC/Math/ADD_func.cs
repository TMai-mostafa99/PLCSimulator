using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADD_func : MathFunc
{
    // Update is called once per frame
    void Update()
    {
        if (EN && !previousSignal) OUT = Num1 + Num2;
        previousSignal = SignalIn.Signal;
    }
}
