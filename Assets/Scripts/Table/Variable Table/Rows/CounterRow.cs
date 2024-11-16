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
    public BoolRow CD;
    public BoolRow R;
    public BoolRow LD;
    public BoolRow Q;
    public List<Counter> AssignedCounters;

    
    private new void Update()
    {
        base.Update();
        ToggleCounterRows(toggleRows.isOn);
    }
    private void RenameComponents(string rowName)
    {
        CU.VarName = rowName + ".CU";
        CD.VarName = rowName + ".CD";
        R.VarName  = rowName + ".R";
        LD.VarName  = rowName + ".LD";
        Q.VarName  = rowName + ".Q";
        PV.VarName = rowName + ".PV";
        CV.VarName = rowName + ".CV";
    }
    public void AddRestToVarTable(string rowName)
    {
        RenameComponents(rowName);
        VarTablemanager.instance.Rows.Add(CU);
        VarTablemanager.instance.Rows.Add(CD);
        VarTablemanager.instance.Rows.Add(R);
        VarTablemanager.instance.Rows.Add(LD);
        VarTablemanager.instance.Rows.Add(Q);
        VarTablemanager.instance.Rows.Add(PV);
        VarTablemanager.instance.Rows.Add(CV);
    }
    public void UpdateAssignedCountersList()
    {
        if (AssignedCounters.Count > 0)
        {

            foreach (Counter counter in AssignedCounters)
            {
                
                PV.AssignedSignals.Add(counter.PV);
                CV.AssignedSignals.Add(counter.CV);
                CU.AssignedSignals.Add(counter.CU);
                R.AssignedSignals.Add(counter.R);
                Q.AssignedSignals.Add(counter.Q);
                LD.AssignedSignals.Add(counter.LD);
                CD.AssignedSignals.Add(counter.CD);

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
            CD.gameObject.SetActive(true);
            LD.gameObject.SetActive(true);

        }
        else
        {
            PV.gameObject.SetActive(false);
            CV.gameObject.SetActive(false);
            CU.gameObject.SetActive(false);
            R.gameObject.SetActive(false);
            Q.gameObject.SetActive(false);
            CD.gameObject.SetActive(false);
            LD.gameObject.SetActive(false);

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
        Destroy(CD.gameObject);
        Destroy(LD.gameObject);
        Destroy(gameObject);
        //TODO: Unsubscribe?
    }
}
