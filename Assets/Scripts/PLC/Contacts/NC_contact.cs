using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_contact : Contact
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SignalOut = RungSignal && !SignalIn;
    }
}
