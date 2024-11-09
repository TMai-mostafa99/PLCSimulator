using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberRow : TableRow
{
    public TMP_InputField input;
    public int Value;


    protected override void Update()
    {
        base.Update();

        if(input.text != string.Empty)
            Value = int.Parse(input.text);
    }
}
