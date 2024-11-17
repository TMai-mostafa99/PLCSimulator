using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PLCComponent : SimulationComponent , IPointerClickHandler
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
    public PLCComponent instance;
    protected void Awake()
    {
        Data.Clear();
        instance = this;
    }
    protected virtual void Start()
    {
        draggable = GetComponent<draggable>();
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
    public void ResetAdding() { addedToRung = false; }
    //public void AssignPLCcomponent(PLCComponent comp)
    //{
    //    if (addedToRung)
    //    {
    //        if (assignVariable.instance == null) return;
    //        Debug.Log("PLC Original: " + gameObject.name);
    //        //assignVariable.instance.OpenPanel.Invoke(this);
    //        assignVariable.instance.OpenVarAssignPanel(comp);
    //    }
           
    //}
    public void OnPointerClick(PointerEventData eventData)
    {
        if (assignVariable.instance == null) return;
        if (addedToRung)
        {
            if (assignVariable.instance == null) return;
            Debug.Log("PLC Original: " + gameObject.name);
            //assignVariable.instance.OpenPanel.Invoke(this);
            assignVariable.instance.OpenVarAssignPanel(instance);
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