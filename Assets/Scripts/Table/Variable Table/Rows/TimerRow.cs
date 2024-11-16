using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerRow : TableRow
{
    public Toggle toggleRows;

    public BoolRow IN;
    public BoolRow R;
    public BoolRow Q;

    public NumberRow PT;
    public NumberRow ET;

    public List<Timer> AssignedTimers;

    protected override void Update()
    {
        base.Update();
        ToggleCounterRows(toggleRows.isOn);

    }
    public void RenameComponents(string rowName)
    {
        IN.VarName = rowName + ".IN";
        R.VarName = rowName + ".R";
        Q.VarName = rowName + ".Q";
        PT.VarName = rowName + ".PT";
        ET.VarName = rowName + ".ET";
    }
    public void AddRestToVarTable(string rowName)
    {
        RenameComponents(rowName);
        VarTablemanager.instance.Rows.Add(IN);
        VarTablemanager.instance.Rows.Add(R);
        VarTablemanager.instance.Rows.Add(Q);
        VarTablemanager.instance.Rows.Add(PT);
        VarTablemanager.instance.Rows.Add(ET);
    }
    public void UpdateAssignedTimersList() 
    {
        if(AssignedTimers.Count > 0)
        {
            foreach(Timer timer in AssignedTimers)
            {
                IN.AssignedSignals.Add(timer.IN);
                R.AssignedSignals.Add(timer.R);
                Q.AssignedSignals.Add(timer.Q);

                PT.AssignedSignals.Add(timer.PT);
                ET.AssignedSignals.Add(timer.ET);
            }
        }
    }
    private void ToggleCounterRows(bool state)
    {
        if (state)
        {
            IN.gameObject.SetActive(true);
            R.gameObject.SetActive(true);
            Q.gameObject.SetActive(true);

            PT.gameObject.SetActive(true);
            ET.gameObject.SetActive(true);
        }
        else
        {
            IN.gameObject.SetActive(false);
            R.gameObject.SetActive(false);
            Q.gameObject.SetActive(false);

            PT.gameObject.SetActive(false);
            ET.gameObject.SetActive(false);
        }
    }
    public override void DeleteRow()
    {
        VarTablemanager.instance.Rows.Remove(this);
        Destroy(IN.gameObject);
        Destroy(Q.gameObject);
        Destroy(R.gameObject);

        Destroy(PT.gameObject);
        Destroy(ET.gameObject);
        Destroy(gameObject);
    }

}
