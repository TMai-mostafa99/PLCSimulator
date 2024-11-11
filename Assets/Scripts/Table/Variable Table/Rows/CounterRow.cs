using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CounterRow : TableRow
{
    public Toggle toggleRows;
    public NumberRow PV;
    public NumberRow CV;
    public BoolRow CU;
    public BoolRow R;
    public BoolRow Q;

    public Action CounterAssigned;
    private new void Update()
    {
        base.Update();
        ToggleCounterRows(toggleRows.isOn);
    }

    private void ToggleCounterRows(bool state)
    {
        if (state)
        {
            PV.gameObject.SetActive(true);
            CV.gameObject.SetActive(true);
            CU.gameObject.SetActive(true);
            R.gameObject.SetActive(true);
            Q.gameObject.SetActive(true);

        }
        else
        {
            PV.gameObject.SetActive(false);
            CV.gameObject.SetActive(false);
            CU.gameObject.SetActive(false);
            R.gameObject.SetActive(false);
            Q.gameObject.SetActive(false);

        }
    }
    public override void DeleteRow()
    {
        VarTablemanager.instance.Rows.Remove(this);
        Destroy(PV.gameObject);
        Destroy(CV.gameObject);
        Destroy(CU.gameObject);
        Destroy(R.gameObject);
        Destroy(Q.gameObject);
        Destroy(gameObject);
        //TODO: Unsubscribe?
    }
}
