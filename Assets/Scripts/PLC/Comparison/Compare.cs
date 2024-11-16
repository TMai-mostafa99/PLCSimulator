using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Compare : PLCComponent
{
    public SignalData NUM1;
    public SignalData NUM2;
    public TMP_Text AssignedVar1;
    public TMP_Text AssignedVar2;
    protected override void Start()
    {
        base.Start();
        NUM1 = new SignalData(VarTypes.NUMBER, "NUM1", false, 0, true);
        NUM2 = new SignalData(VarTypes.NUMBER, "NUM2", false, 0, true);

        Data.Add(NUM1);
        Data.Add(NUM2);
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        SignalIn = RungSignal;
        if (AssignedVar1 != null)
        {
            if (addedToRung) AssignedVar1.gameObject.SetActive(true);
            else AssignedVar1.gameObject.SetActive(false);
            AssignedVar1.text = NUM1.assignedrow ? NUM1.assignedrow.VarName : "???";
        }
        if (AssignedVar2 != null)
        {
            if (addedToRung) AssignedVar2.gameObject.SetActive(true);
            else AssignedVar2.gameObject.SetActive(false);
            AssignedVar2.text = NUM2.assignedrow ? NUM2.assignedrow.VarName : "???";
        }
    }
}
