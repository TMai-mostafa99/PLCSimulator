using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RungComponent : SimulationComponent
{
    public List<SimulationComponent> components;
    public bool isParallel; // set from prefab
    //parallel means it is a mini rung
    public bool previousSignalOut;

    public void FillRung()
    {
        components.Clear();
        foreach (Transform child in transform)
        {
            SimulationComponent component = child.GetComponent<SimulationComponent>();
            components.Add(component);
        }
    }
    public void SetInitialSignal(bool initialSignal)
    {
        if(components.Count > 0 && components[0] is PLCComponent x)
        {
            x.SignalIn = initialSignal;
        }
    }



    public bool ExecuteRung()
    {
        foreach (SimulationComponent comp in components)
        {
            if (comp is PLCComponent x)
            {
                x.RungSignal = previousSignalOut;
                previousSignalOut = x.SignalOut;
            }
            else if (comp is RungComponent r)
            {
                r.SetInitialSignal(previousSignalOut);
                previousSignalOut = r.ExecuteRung();
            }

            //if (isParallel && previousResult) return true;

            //if (!isParallel && !previousResult) return false;
        }
        return previousSignalOut;
      
    }
    //private void Update()
    //{
       
    //}
}
