using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RungComponent : SimulationComponent
{
    public List<SimulationComponent> componentsPanel1;
    public List<SimulationComponent> componentsPanel2;
    public bool isParallel; // set from prefab
    //parallel means it is a mini rung
    public bool SignalInForRung;
    [Button]
    public void FillRung()
    {
        componentsPanel1.Clear();
        componentsPanel2.Clear();
        if (isParallel)
        {
            TraverseChildren(transform, (panel) =>
           {
               if (panel.GetComponent<miniparallel_rung>())
               {
                   TraverseChildren(panel, (child) =>
                    {
                        SimulationComponent component = child.GetComponent<SimulationComponent>();
                        componentsPanel1.Add(component);
                    });
               }
               if (panel.GetComponent<miniparallel_rung2>())
               {
                   TraverseChildren(panel, (child) =>
                   {
                       SimulationComponent component = child.GetComponent<SimulationComponent>();
                       componentsPanel2.Add(component);
                   });
               }


           });
        }
        else
        {
            TraverseChildren(transform.GetChild(0).GetChild(0), (child) =>
            {
               SimulationComponent component = child.GetComponent<SimulationComponent>();
               componentsPanel1.Add(component);
            });
        }
    }
    public void SetInitialSignal(bool initialSignal)
    {
        SignalInForRung = initialSignal;
    }

    public bool ExecuteRung()
    {
        FillRung();
        if (isParallel)
            return ExecutePanel(componentsPanel1) || ExecutePanel(componentsPanel2);
        else
            return ExecutePanel(componentsPanel1);
    }

    public bool ExecutePanel(List<SimulationComponent> components)
    {
        bool signalOut = SignalInForRung;
        foreach (SimulationComponent comp in components)
        {
            if (comp is PLCComponent x)
            {
                x.RungSignal.Signal = signalOut;
                signalOut = x.SignalOut.Signal;
            }
            else if (comp is RungComponent r)
            {
                r.SetInitialSignal(signalOut);
                signalOut = r.ExecuteRung();

            }
        }
        return signalOut;
      
    }
    //---------------------- Helper ------------------------//
    private void TraverseChildren(Transform transformParent, UnityAction<Transform> action)
    {
        foreach (Transform child in transformParent)
        {
            action.Invoke(child);
        }
    }
}
