using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Contact : PLCComponent
{
    public TMP_Text AssignedVar;
    public SignalData Input;

    protected override void Start()
    {
        base.Start();
        Input = new SignalData(VarTypes.BOOL, "Input", false, 0, true);
        Data.Add(Input);
    }

    protected override void Update()
    {
        base.Update();
        SignalIn = Input.Signal;

        if(AssignedVar != null)
        {
            if (addedToRung) AssignedVar.gameObject.SetActive(true);
            else AssignedVar.gameObject.SetActive(false);
            AssignedVar.text = Input.assignedrow ? Input.assignedrow.VarName : "???";
        }

    }
    
}
