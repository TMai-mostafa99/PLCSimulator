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
        PV = new SignalData(VarTypes.NUMBER, "PV", false, 0 , true);
        CV = new SignalData(VarTypes.NUMBER, "CV", false, 0, false);
        CU = new SignalData(VarTypes.BOOL, "CU", false, 0, false);
        Q = new SignalData(VarTypes.BOOL, "Q", false, 0,false);
        R = new SignalData(VarTypes.BOOL, "R", false, 0, true);
        //Data.Add(PV);
        //Data.Add(CV);
        //Data.Add(CU);
        //Data.Add(Q);
        //Data.Add(R);

    }
    //public void Set_counter(bool _cu, bool _Q, bool _R, int _PV, int _CV)
    //{
    //    _cu = CU.Signal;
    //    _Q = Q.Signal;
    //    R.Signal = _R;
    //    PV.Number = _PV;
    //    _CV = CV.Number;
    //}
}
