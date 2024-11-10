using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLCComponent : SimulationComponent
{
    public bool RungSignal;
    public bool SignalIn;
    public bool SignalOut;

    protected bool addedToRung;
    private draggable draggable;

    public List<SignalData> Data;

    private void OnValidate()
    {
        SignalData RungSignalT = new SignalData();
        RungSignalT.SignalName = "RungSignal";
        RungSignalT.Type = VarTypes.BOOL;
        Data.Add(RungSignalT);
    }
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

    public void SetSignalIn(bool signal)
    {
        SignalIn = signal;
    }
    private Action<bool> currentSubscription;  // Stores current subscription for dynamic unsubscription

    // Method to dynamically subscribe to any boolean change event
    //public void SubscribeToBoolChange(Action<bool> boolChangeEvent)
    //{
    //    // If already subscribed to the same event, do nothing
    //    if (currentSubscription == boolChangeEvent)
    //        return;

    //    // Unsubscribe from the previous event if it's assigned to a different event
    //    if (currentSubscription != null)
    //    {
    //        currentSubscription -= OnBoolChanged;
    //    }

    //    // Update the subscription to the new event
    //    currentSubscription = boolChangeEvent;
    //    currentSubscription += OnBoolChanged;
    //}

    [Serializable]
    public class SignalData
    {
        public VarTypes Type;
        public string SignalName;
        public bool Signal;
        public int Number;
        public UnityAction<bool> currentSubscriptionSignal;
        public UnityAction<bool> currentSubscriptionNumber;
    }
}