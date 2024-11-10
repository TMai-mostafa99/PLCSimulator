using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoolRow : TableRow
{
    public Toggle togglebool;
    private bool _value;

    public UnityAction<bool> OnValueChanged;
    public bool Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Value = togglebool.isOn;
    }
}
