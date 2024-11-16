using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : PLCComponent
{
    public SignalData Title;
    public SignalData PV; //preset value//int
    public SignalData CV; //Current value;//int
    public SignalData CU;
    public SignalData CD;
    public SignalData LD;
    public SignalData Q;
    public SignalData R;
    //--------------------------------//
    protected bool previousSignalIn;
    public TMP_Text AssignedVar1;
    
    private new void Awake()
    {
        base.Awake();
        Title = new SignalData(VarTypes.COUNTER, "???", false, 0, false);
        PV = new SignalData(VarTypes.NUMBER, "PV", false, 0, true);
        CV = new SignalData(VarTypes.NUMBER, "CV", false, 0, false);
        CU = new SignalData(VarTypes.BOOL, "CU", false, 0, false);
        Q = new SignalData(VarTypes.BOOL, "Q", false, 0, false);
        R = new SignalData(VarTypes.BOOL, "R", false, 0, true);
        LD = new SignalData(VarTypes.BOOL, "LD", false, 0, true);
        CU = new SignalData(VarTypes.BOOL, "CD", false, 0, false);
    }

    protected override void Update()
    {
        base.Update();
        if (AssignedVar1 != null)
        {
            if (addedToRung) AssignedVar1.gameObject.SetActive(true);
            else AssignedVar1.gameObject.SetActive(false);
            AssignedVar1.text =  Title.SignalName ;
        }
    }
}
