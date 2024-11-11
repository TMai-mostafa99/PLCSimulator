using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.Events;
public class AssignRow : MonoBehaviour
{
    public PLCComponent.SignalData Signal;
    public TMP_Text VarName;
    public TMP_Dropdown dropDown;
    //public int prevDropDownVal = -1;
    // Start is called before the first frame update
    void Start()
    {
        dropDown.onValueChanged.AddListener(AssignVariableToComponent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AssignVariableToComponent(int indx)
    {
      //  Debug.Log("CALLLLED");
        switch (Signal.Type)
        {
            case VarTypes.BOOL:
                BoolRow row = (BoolRow) VarTablemanager.instance.Rows.Find(row => row.VarName == dropDown.options[indx].text);
                 Signal.SubscribeToBoolChange(row);
                //prevDropDownVal = indx;
                break;

            case VarTypes.NUMBER:
                NumberRow rowNum = (NumberRow)VarTablemanager.instance.Rows.Find(row => row.VarName == dropDown.options[indx].text);
                Signal.SubscribeToNumberChange(rowNum);
                //dropDown.value = indx;
                break;
        }
     
    }

}
