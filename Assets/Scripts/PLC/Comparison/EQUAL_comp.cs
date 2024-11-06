using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQUAL_comp : Compare
{
    // Update is called once per frame
    void Update()
    {
        SignalOut = NUM1 == NUM2 ? true : false;
    }
}
