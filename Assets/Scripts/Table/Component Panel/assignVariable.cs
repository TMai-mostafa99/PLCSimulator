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
    public FieldInfo[] fields;
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
       // if(fields.Length >0 )   Array.Clear(fields, 0, fields.Length);
        DestroyAllChildren();
        //Destroy all chidren of parent;
       // Debug.Log("plc name: " + plc.name);
        //GetPublicVariables(plc);
        GetPLCdata(plc);
    }
    public void GetPLCdata(PLCComponent plc)
    {
        foreach(PLCComponent.SignalData signal in plc.Data)
        {
          //  Debug.Log("NAME SIGNAL : " + signal.SignalName);
            if (signal.SignalName == "SignalOut" || signal.SignalName == "RungSignal")
            { //DONT
            }
            else
            {
                GameObject row = Instantiate(AssignRowgGo, VarParent);
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
