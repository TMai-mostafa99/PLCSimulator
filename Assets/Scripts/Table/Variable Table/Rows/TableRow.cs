using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableRow : MonoBehaviour
{
    public TMP_Text Name;
    public string VarName;
    public VarTypes type;
    public Button Delete;

    private void Start()
    {
      if(Delete)  Delete.onClick.AddListener(DeleteRow);
    }
    protected virtual void Update()
    {
      
        Name.text = VarName;
    }

    public  virtual void DeleteRow() 
    {
        VarTablemanager.instance.Rows.Remove(this);
        Destroy(gameObject);
    }
}
