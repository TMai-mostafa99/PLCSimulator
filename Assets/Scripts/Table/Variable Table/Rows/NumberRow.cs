using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class NumberRow : TableRow,INumberSubscribable
{
    public TMP_InputField input;
   
    private int _value;
    public Action<int> OnValueChanged;
    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }

    public int numberValue => Value;

    protected override void Update()
    {
        base.Update();

        if(input.text != string.Empty)
            _value = int.Parse(input.text);
    }

    public void Subscribe(Action<int> callback)
    {
        OnValueChanged += callback;
    }

    public void UnSubscribe(Action<int> callback)
    {
        OnValueChanged -= callback;
    }
}
