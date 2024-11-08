using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLCExecution : MonoBehaviour
{
    //we will start with 1 rung
    // Start is called before the first frame update
    public GameObject Parent;
    public List<RungComponent> MainRungs;
    public bool isRunning;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            foreach(RungComponent rung in MainRungs)
            {
                rung.ExecuteRung();
            }
        }
    
    }
    public void Run()
    {
        foreach (Transform child in Parent.transform)
        {
            RungComponent comp = child.GetComponent<RungComponent>();
            comp.SetInitialSignal(true);
            MainRungs.Add(comp);
         
        }
        isRunning = true;

    }
    private void GetRungElements(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            PLCComponent component = child.GetComponent<PLCComponent>();
            if (!component) return;
            if(component is Counter)//RUNG
            {
                GetRungElements(component.transform);
            }
        }
    }
}
