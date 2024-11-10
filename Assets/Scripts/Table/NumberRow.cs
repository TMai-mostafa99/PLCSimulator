using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class NumberRow : TableRow
{
    public TMP_InputField input;
   
    private int _value;
    public UnityAction<int> OnValueChanged;
    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }
    protected override void Update()
    {
        base.Update();

        if(input.text != string.Empty)
            _value = int.Parse(input.text);
    }

}
