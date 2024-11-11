using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NO_contact : Contact
{

    // Update is called once per frame
    void Update()
    {
        SignalOut.Signal = RungSignal.Signal && SignalIn.Signal ;
    }


}
