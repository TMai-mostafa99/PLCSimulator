using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_contact : Contact
{
    // Update is called once per frame
    void Update()
    {
        SignalOut.Signal = RungSignal.Signal && !SignalIn.Signal;
    }
    private void OnMouseDown()
    {
        if (addedToRung)
        {
            //TODO: Open Var Panel
            assignVariable.instance.OpenPanel.Invoke(this);
        }
    }
}
