using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQUAL_comp : Compare
{
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        SignalOut = NUM1 == NUM2 ? true : false;
    }
}
