using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VarTablemanager : MonoBehaviour //Mark as singleton
{
    public TMP_InputField Name;
    public TMP_Dropdown dropdown;
   // public Button AddBtn;
    public List<TableRow> Rows;
    public Transform TableParent;
    public GameObject BoolRow;
    public GameObject NumberRow;

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

            case 1:
                GameObject NumberRowObj = Instantiate(NumberRow, TableParent);
                NumberRow NumberRowEle = NumberRowObj.GetComponent<NumberRow>();
                NumberRowEle.VarName = Name.text;
                Rows.Add(NumberRowEle);
                break;
        }
    }

 
}
