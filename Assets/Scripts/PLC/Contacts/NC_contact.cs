using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_contact : Contact
{
    // Update is called once per frame
   protected override void Update()
    {
        base.Update();
   
        SignalOut = RungSignal && !SignalIn;
    }
}
