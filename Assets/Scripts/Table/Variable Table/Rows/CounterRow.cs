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

    public List<Counter> AssignedCounters;

    
    private new void Update()
    {
        base.Update();
        ToggleCounterRows(toggleRows.isOn);


       if(AssignedCounters.Count > 0)
        {
            foreach(Counter counter in AssignedCounters)
            {
                PV.AssignedSignals.Add(counter.PV);
                CV.AssignedSignals.Add(counter.CV);
                CU.AssignedSignals.Add(counter.CU);
                R.AssignedSignals.Add(counter.CU);
                Q.AssignedSignals.Add(counter.Q);

            }
       
        }
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
