using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.Events;

public class assignVariable : MonoBehaviour //also singleton
{
    public UnityAction<PLCComponent> OpenPanel;
  //  public PLCComponent component;
    public Transform VarParent;
    public GameObject AssignRowgGo;
    public GameObject PopUpPanel;
    public static assignVariable instance;

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        OpenPanel += OpenVarAssignPanel;
    }
 public void DestroyAllChildren()
    {
        foreach (Transform child in VarParent)
        {
            Destroy(child.gameObject);
        }
    }
    public void OpenVarAssignPanel(PLCComponent plc)
    {
        PopUpPanel.SetActive(true);
        DestroyAllChildren();
        GetPLCdata(plc);
    }
    public void GetPLCdata(PLCComponent plc)
    {
        if (plc is Counter )
        {
            Counter CounterPLC =(Counter) plc;
            GameObject row = Instantiate(AssignRowgGo, VarParent);
            row.GetComponent<AssignRow>().VarName.text = "Counter Data";
            List<TMP_Dropdown.OptionData> Counteroptions = GetOptions(VarTypes.COUNTER);
            row.GetComponent<AssignRow>().dropDown.AddOptions(Counteroptions);
            PLCComponent.SignalData counterSignal = new PLCComponent.SignalData(VarTypes.COUNTER, "sig", false, 0 , false);
            row.GetComponent<AssignRow>().Signal = counterSignal;
            row.GetComponent<AssignRow>().component = plc;
            

        }
        else if (plc is Timer)
        {
            GameObject row = Instantiate(AssignRowgGo, VarParent);
            row.GetComponent<AssignRow>().VarName.text = "Timer Data";
            List<TMP_Dropdown.OptionData> Counteroptions = GetOptions(VarTypes.TIMER);
            row.GetComponent<AssignRow>().dropDown.AddOptions(Counteroptions);
            PLCComponent.SignalData counterSignal = new PLCComponent.SignalData(VarTypes.TIMER, "sig", false, 0, false);
            row.GetComponent<AssignRow>().Signal = counterSignal;
            row.GetComponent<AssignRow>().component = plc;
        }
        else
        {
            foreach (PLCComponent.SignalData signal in plc.Data)
            {
                GameObject row = Instantiate(AssignRowgGo, VarParent);

                if (plc is Timer) row.GetComponent<AssignRow>().VarName.text = "Timer Data";
                else
                    row.GetComponent<AssignRow>().VarName.text = signal.SignalName;

                List<TMP_Dropdown.OptionData> options = GetOptions(signal.Type);
                row.GetComponent<AssignRow>().dropDown.AddOptions(options);
                row.GetComponent<AssignRow>().Signal = signal;
                row.GetComponent<AssignRow>().component = plc;
             
            }
        }
        

    }
    public void CloseVarAssignPanel()
    {
        PopUpPanel.SetActive(false);
    }

    private List<TMP_Dropdown.OptionData> GetOptions(VarTypes type)
    {
       // Debug.Log("type: " + type);
        List<TMP_Dropdown.OptionData> optionsList = new List<TMP_Dropdown.OptionData>();
        foreach (TableRow row in VarTablemanager.instance.Rows)
        {

            if (row.type == type)
            {
                TMP_Dropdown.OptionData item = new TMP_Dropdown.OptionData();
                item.text = row.VarName;
                optionsList.Add(item);
            }

        }
        return optionsList;
    }
}
