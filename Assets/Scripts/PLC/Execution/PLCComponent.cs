using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PLCComponent : SimulationComponent
{
    //public bool RungSignal;
    //public bool SignalIn;
    //public bool SignalOut;
    public SignalData RungSignal;
    public SignalData SignalIn;
    public SignalData SignalOut;

    protected bool addedToRung;
    private draggable draggable;

    public List<SignalData> Data;

    public Image graphic;
    protected void Awake()
    {
        Data.Clear();
        RungSignal = new SignalData(VarTypes.BOOL, "RungSignal", false, 0 , false);
        if (!Data.Contains(RungSignal)) Data.Add(RungSignal);
        SignalIn = new SignalData(VarTypes.BOOL, "SignalIn", false, 0 , true);
        if (!Data.Contains(SignalIn)) Data.Add(SignalIn);
        SignalOut = new SignalData(VarTypes.BOOL, "SignalOut", false, 0 , false);
        if (!Data.Contains(SignalOut)) Data.Add(SignalOut);
    }
    private void OnValidate()
    {
        Data.Clear();
        RungSignal = new SignalData(VarTypes.BOOL, "RungSignal", false, 0, false);
        if (!Data.Contains(RungSignal)) Data.Add(RungSignal);
        SignalIn = new SignalData(VarTypes.BOOL, "SignalIn", false, 0, true);
        if (!Data.Contains(SignalIn)) Data.Add(SignalIn);
        SignalOut = new SignalData(VarTypes.BOOL, "SignalOut", false, 0 , false);
        if (!Data.Contains(SignalOut)) Data.Add(SignalOut);
        // Data.Clear();
    }
    protected virtual void Start()
    {
        Debug.Log("HERE");
        draggable = GetComponent<draggable>();
        Debug.Log("DRAGABALE: " + draggable);
        draggable.Dropped += DroppedToRung;
    }
    protected virtual void Update()
    {
        if (graphic)
        {
            if (SignalOut.Signal) graphic.color = Color.green;
            else graphic.color = Color.black;
        }
       
    }
    private void DroppedToRung()
    {
        addedToRung = true;
    }

    public void AssignPLCcomponent()
    {
        if (addedToRung)
        {
            Debug.Log("HEERE");
            assignVariable.instance.OpenPanel.Invoke(this);
        }
           
    }

    [Serializable]
    public class SignalData
    {
        public VarTypes Type;
        public string SignalName;
        public bool Signal;
        public int Number;
        public bool IsWrite;
        public TableRow assignedrow;
        //private IBoolSubscribable boolSubscribe;
        //private INumberSubscribable numberSubscribe;
        public  SignalData(VarTypes type, string signalName , bool signal , int num , bool isWrite)
        {
            Type = type;
            SignalName = signalName;
            Signal = signal;
            Number = num;
            IsWrite = isWrite;
        }
 

        public bool SetBool(bool boolsignal , TableRow row)
        {
            RemovePreviousConnection(row);
            if (IsWrite)
                Signal = boolsignal;


            return Signal;
        }
        public int SetNumber( int number , TableRow row)
        {
            RemovePreviousConnection(row);
            if (IsWrite) Number = number;

            return Number;
        }
        private void RemovePreviousConnection(TableRow newRow)
        {
            if(assignedrow != null )
            {
                if(assignedrow != newRow)
                    assignedrow.AssignedSignals.Remove(this);
            }
          //  Debug.Log("ASsign row here");
            assignedrow = newRow;

        }
        //public void SubscribeToBoolChange(IBoolSubscribable source)
        //{
        //       if(boolSubscribe != null)
        //        {
        //        boolSubscribe.UnSubscribe(UpdateSignal);
        //        }

        //    boolSubscribe = source;
        //    boolSubscribe.Subscribe(UpdateSignal);

        //    Signal = boolSubscribe.BoolValue;

        //}

        //// Method that will handle the changes from the subscribed events
        //private void UpdateSignal(bool newValue)
        //{
        //    Debug.Log("A1 updated to: " + newValue);
        //    Signal = newValue;
         
        //}
        ////TODO add one for int
        //public void SubscribeToNumberChange(INumberSubscribable source)
        //{
        //    if (numberSubscribe != null)
        //    {
        //        numberSubscribe.UnSubscribe(UpdateNumber);
        //    }

        //    numberSubscribe = source;
        //    numberSubscribe.Subscribe(UpdateNumber);

        //    Number = numberSubscribe.numberValue;

        //}
        //private void UpdateNumber(int newValue)
        //{
        //    Number = newValue;
        //}

    }
}