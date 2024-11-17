using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : PLCComponent
{
    public SignalData Title;
    //Boolrans
    public SignalData IN;
    public SignalData Q;
    public SignalData R;

    //Numbers
    public SignalData PT;
    public SignalData ET;

    protected bool  StartedNow;
    protected float startTime;
    protected bool  previousSignal;
    protected bool timerRunning;

    public TMP_Text AssignedVar1;
    protected override void Start()
    {
        base.Start();

        Init();

        timerRunning = false;
        previousSignal = false;
    }
    public void Init()
    {
        Title = new SignalData(VarTypes.TIMER, "???", false, 0, false);
        IN = new SignalData(VarTypes.BOOL,"IN", false, 0, false);
        Q = new SignalData(VarTypes.BOOL,"Q", false, 0, false);
        R = new SignalData(VarTypes.BOOL, "R", false, 0, true);

        PT = new SignalData(VarTypes.BOOL, "PT", false, 0, true);
        ET = new SignalData(VarTypes.BOOL,  "ET", false, 0, false);

        //not initialized individually
        //Data.Add(IN);
        //Data.Add(Q);
        //Data.Add(R);
        //Data.Add(PT);
        //Data.Add(ET);

        //not initialized individually
        //IN = new SignalData(VarTypes.BOOL, TimerName + ".IN", false, 0, false);
        //Q = new SignalData(VarTypes.BOOL, TimerName + ".Q", false, 0, false);
        //R = new SignalData(VarTypes.BOOL, TimerName + ".R", false, 0, true);

        //PT = new SignalData(VarTypes.BOOL, TimerName + ".PT", false, 0, true);
        //ET = new SignalData(VarTypes.BOOL, TimerName + ".ET", false, 0, false);
    }
    protected bool CheckifAllAssigned()
    {
        if (IN.assignedrow == null) return false;
        if (Q.assignedrow == null) return false;
        if (R.assignedrow == null) return false;
        if (PT.assignedrow == null) return false;
        if (ET.assignedrow == null) return false;

        return true;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        IN.Signal = SignalIn = RungSignal;
        if (R.Signal) 
        { 
            ET.Number = 0;
            StartedNow = false;
        
        } //reset bit

        if (AssignedVar1 != null)
        {
            if (addedToRung) AssignedVar1.gameObject.SetActive(true);
            else AssignedVar1.gameObject.SetActive(false);
            AssignedVar1.text = Title.SignalName;
        }
    }
}
