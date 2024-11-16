using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class AssignRow : MonoBehaviour
{
    public PLCComponent component;
    public PLCComponent.SignalData Signal;
    public TMP_Text VarName;
    public TMP_Dropdown dropDown;
    // Start is called before the first frame update
    void Start()
    {
        dropDown.onValueChanged.AddListener(AssignVariableToComponent);
    }

    public void AssignVariableToComponent(int indx)
    {
      //  Debug.Log("CALLLLED");
        switch (Signal.Type)
        {
            case VarTypes.BOOL:
                BoolRow row = (BoolRow) VarTablemanager.instance.Rows.Find(row => row.VarName == dropDown.options[indx].text);
                if(!row.AssignedSignals.Contains(Signal)) row.AssignedSignals.Add(Signal);


                break;

            case VarTypes.NUMBER:
                NumberRow rowNum = (NumberRow)VarTablemanager.instance.Rows.Find(row => row.VarName == dropDown.options[indx].text);
                 if(!rowNum.AssignedSignals.Contains(Signal)) rowNum.AssignedSignals.Add(Signal);
                break;
            case VarTypes.COUNTER:
                CounterRow counterRow = (CounterRow)VarTablemanager.instance.Rows.Find(row => row.VarName == dropDown.options[indx].text);
                if (!counterRow.AssignedCounters.Contains((Counter)component)) 
                {
                    Counter counter = (Counter)component;
                    counter.Title.SignalName = dropDown.options[indx].text;
                    counterRow.AssignedCounters.Add((Counter)component);
                    counterRow.UpdateAssignedCountersList();
                } 
                break;
            case VarTypes.TIMER:
                TimerRow timerRow = (TimerRow)VarTablemanager.instance.Rows.Find(row => row.VarName == dropDown.options[indx].text);
                if (!timerRow.AssignedTimers.Contains((Timer)component))
                {
                    Timer currComponent = (Timer)component;
                    timerRow.AssignedTimers.Add((Timer)component);
                    timerRow.UpdateAssignedTimersList();
                }
            
                break;
        }
     
    }

}
