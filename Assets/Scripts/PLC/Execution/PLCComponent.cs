using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class PLCComponent : SimulationComponent
{
    //public bool RungSignal;
    //public bool SignalIn;
    //public bool SignalOut;
    public bool RungSignal;
    public bool SignalIn;
    public bool SignalOut;

    [SerializeField] protected bool addedToRung;
    [SerializeField]private draggable draggable;

    public List<SignalData> Data;

    public Image graphic;
    protected void Awake()
    {
        Data.Clear();
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
            if (SignalOut) graphic.color = Color.green;
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
            if (assignVariable.instance == null) return;
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
    }
}