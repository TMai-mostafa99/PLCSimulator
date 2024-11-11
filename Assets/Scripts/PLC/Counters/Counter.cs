using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : PLCComponent
{
    public SignalData PV; //preset value//int
    public SignalData CV; //Current value;//int
    public SignalData CU;
    public SignalData Q;
    public SignalData R;

    private new void Awake()
    {
        base.Awake();
        PV = new SignalData(VarTypes.NUMBER, "PV", false, 0);
        CV = new SignalData(VarTypes.NUMBER, "CV", false, 0);
        CU = new SignalData(VarTypes.BOOL, "CU", false, 0);
        Q = new SignalData(VarTypes.BOOL, "Q", false, 0);
        R = new SignalData(VarTypes.BOOL, "R", false, 0);
        //Data.Add(PV);
        //Data.Add(CV);
        //Data.Add(CU);
        //Data.Add(Q);
        //Data.Add(R);

    }

}
