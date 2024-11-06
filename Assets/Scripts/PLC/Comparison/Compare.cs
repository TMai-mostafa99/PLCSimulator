using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compare : PLCComponent
{
    public int NUM1;
    public int NUM2;
    // Update is called once per frame
    void Update()
    {
        SignalIn = RungSignal;

    }
}
