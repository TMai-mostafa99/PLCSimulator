using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VarTablemanager : MonoBehaviour //Mark as singleton
{
    public TMP_InputField Name;
    public TMP_Dropdown dropdown;
    public Button AddBtn;
    public List<TableRow> Rows;
    public Transform TableParent;
    public GameObject BoolRow;
    public GameObject NumberRow;
    public GameObject CounterRow;
    public GameObject TimerRow;
    public static VarTablemanager instance;

    private void Awake()
    {
        instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO :
        //ClosePopUp ADD BUTTON IF TEXT IS EMPTY
        if (Name.text == string.Empty)
        {
            AddBtn.interactable = false;
        }
        else
        {
            AddBtn.interactable = true;
        }
       Rows.ForEach(row =>
            {
                if (row.VarName == Name.text) AddBtn.interactable = false;
                else AddBtn.interactable = true;
            });
    }

    public void AddRow()
    {
        switch (dropdown.value)
        {
            case 0://Bool
                GameObject BoolRowObj = Instantiate(BoolRow, TableParent);
                BoolRow BoolRowEle = BoolRowObj.GetComponent<BoolRow>();
                BoolRowEle.VarName = Name.text;
                Rows.Add(BoolRowEle);
                break;

            case 1://Number
                GameObject NumberRowObj = Instantiate(NumberRow, TableParent);
                NumberRow NumberRowEle = NumberRowObj.GetComponent<NumberRow>();
                NumberRowEle.VarName = Name.text;
                Rows.Add(NumberRowEle);
                break;

            case 2: //Counter
                GameObject CounterRowParent = Instantiate(CounterRow, TableParent); //counter row
                CounterRow CounterRowEle = CounterRowParent.transform.GetChild(0).GetComponent<CounterRow>();
                ReparentChildrenAndDeleteParent(CounterRowParent.transform);
                CounterRowEle.VarName = Name.text;
                Rows.Add(CounterRowEle);
                CounterRowEle.AddRestToVarTable(CounterRowEle.VarName);
                break;

            case 3:
                GameObject TimerRowParent = Instantiate(TimerRow, TableParent); //counter row
                TimerRow TimerRowEle = TimerRowParent.transform.GetChild(0).GetComponent<TimerRow>();
                ReparentChildrenAndDeleteParent(TimerRowParent.transform);
                TimerRowEle.VarName = Name.text;

                Rows.Add(TimerRowEle);
                TimerRowEle.AddRestToVarTable(TimerRowEle.VarName);
                break;
        }
    }
    public void ReparentChildrenAndDeleteParent(Transform OldParent)
    {
        
        // Check if the object has a parent
        if (OldParent.parent == null)
        {
            Debug.LogWarning("This object has no parent, so its children cannot be made siblings.");
            return;
        }

        // Get the parent of the original parent (the grandparent)
        Transform grandParent = OldParent.parent;

        // Reparent each child to the grandparent
        while (OldParent.childCount > 0)
        {
            Transform child = OldParent.GetChild(0);
            child.SetParent(grandParent, true); // 'true' keeps the child's world position
        }

        // Destroy the original parent (this GameObject)
        Destroy(OldParent.gameObject);
    }

}
