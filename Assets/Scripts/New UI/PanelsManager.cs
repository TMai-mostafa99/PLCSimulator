using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsManager : MonoBehaviour
{
    public Panel[] Panels;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Panel pnl in Panels)
        {
            GameObject PanelGO = pnl.PanelGo;
            pnl.btn.onClick.AddListener(() => { OpenPanel(PanelGO); });
        }
            
    }
    public void OpenPanel(GameObject panel)
    {
       
        foreach(Panel pnl in Panels)
        {
          //  Debug.Log("PANEL NAME: " + panel.name + " GO : " + pnl.PanelGo.name);
            if(pnl.PanelGo == panel)
            {
                pnl.PanelGo.SetActive(true);
            }
            else
            {
                pnl.PanelGo.SetActive(false);
            }
        }
    }

    [Serializable]
    public class Panel
    {
        public Button btn;
        public GameObject PanelGo;
    }
}
