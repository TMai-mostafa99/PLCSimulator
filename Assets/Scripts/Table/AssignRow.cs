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
    public PLCComponent component;
    public TMP_Text VarName;
    public TMP_Dropdown dropDown;
    public VarTypes type;
    private FieldInfo currInfo;
    // Start is called before the first frame update
    void Start()
    {
        dropDown.onValueChanged.AddListener(SetPublicVariables);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AssignVariableToComponent()
    {

    }
    public void SetPublicVariables(int indx)
    {
        if (component == null)
        {
            Debug.LogWarning("No target script assigned.");
            return;
        }

        Type type = component.GetType();
        FieldInfo[] fields;
        fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            // Get
            
           TableRow row = VarTablemanager.instance.Rows.Find(row => row.VarName == dropDown.options[indx].text);
            // Debug.Log("")
            Debug.Log("row.VarName:  " + row.VarName);
            if (field.Name == VarName.text)
            {
                object value = field.GetValue(component);

                if (row is NumberRow numRow)
                {

                    Debug.Log($"NUMBER Field: {field.Name}, Value: {value}");
                    currInfo = field;
                    numRow.OnValueChanged += SetNumFieldValue;//field.SetValue(component, numRow.Value);

                   
                }
                if (row is BoolRow boolRow)
                {

                    Debug.Log($" BOOL Field: {field.Name}, Value: {value}");
                    currInfo = field;
                    boolRow.OnValueChanged -= this.SetBoolFieldValue;
                    boolRow.OnValueChanged += SetBoolFieldValue;//field.SetValue(component, numRow.Value);   

                    
                   
                        
                }
            }
        }
    }
    public void SetNumFieldValue(int num )
    {
        currInfo.SetValue(component, num);
    }
    public void SetBoolFieldValue(bool val)
    {
        currInfo.SetValue(component, val);
    }
}
