using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLCExecution : MonoBehaviour
{
    //we will start with 1 rung
    // Start is called before the first frame update
    public GameObject Parent;
    public PLCComponent[] components;
    public bool isRunning;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning && components.Length > 0)
        {
            for (int i = 0; i < components.Length; i++)
            {
                if (i == 0) components[0].RungSignal = true;
                else
                {
                    components[i].RungSignal = components[i - 1].SignalOut;
                }
            }
        }
    }
    public void Run()
    {
        components = Parent.GetComponentsInChildren<PLCComponent>();
        isRunning = true;
     
    }
}
