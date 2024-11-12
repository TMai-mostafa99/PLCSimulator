using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NO_contact : Contact
{

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        SignalOut.Signal = RungSignal.Signal && SignalIn.Signal ;
    }


}
