using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLCComponent : SimulationComponent
{
    public bool RungSignal;
    public bool SignalIn;
    public bool SignalOut;

    protected bool addedToRung;
    private draggable draggable;

    private void Start()
    {
        Debug.Log("HERE");
        draggable = GetComponent<draggable>();
        Debug.Log("DRAGABALE: " + draggable);
        draggable.Dropped += DroppedToRung;
    }
    private void DroppedToRung()
    {
        addedToRung = true;
    }

    public void AssignPLCcomponent(MonoBehaviour plccomp)
    {
        if(addedToRung)
        assignVariable.instance.OpenPanel.Invoke(plccomp);
    }
   
}