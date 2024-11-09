using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolRow : TableRow
{
    public Toggle togglebool;
    public bool Value;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Value = togglebool.isOn;
    }
}
