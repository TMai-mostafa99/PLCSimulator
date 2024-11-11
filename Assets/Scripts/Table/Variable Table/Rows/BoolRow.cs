using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoolRow : TableRow,IBoolSubscribable
{
    public Toggle togglebool;
    private bool _value;

    //public bool FValue => Value;
    public Action<bool> OnValueChanged;
    public bool Value
    {
        get { return _value; }
        set
        {
            if(value != _value)
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
                Debug.Log("bool changed");
            }
            
        }
    }

    public bool BoolValue => Value;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Value = togglebool.isOn;
    }

    public void Subscribe(Action<bool> callback)
    {
        OnValueChanged += callback;
    }

    public void UnSubscribe(Action<bool> callback)
    {
        OnValueChanged -= callback;
    }
}
