using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Basic_Coil : Coil
{
    public TMP_Text AssignedVar;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        SignalOut = RungSignal;
        Output.Signal = SignalOut; // can't be changed from outside but can only be viewed
        if (AssignedVar != null)
        {
            if (addedToRung) AssignedVar.gameObject.SetActive(true);
            else AssignedVar.gameObject.SetActive(false);
            AssignedVar.text = Output.assignedrow ? Output.assignedrow.VarName : "???";
        }
    }
}
