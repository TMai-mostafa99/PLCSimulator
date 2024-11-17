using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleterung : MonoBehaviour
{
    private RungComponent thisRung;

    private void Start()
    {
        thisRung = GetComponent<RungComponent>();
    }

    public void destroyrung()
    {
        if (PLCExecution.instance.MainRungs.Contains(thisRung)) PLCExecution.instance.MainRungs.Remove(thisRung);
        Destroy(this.gameObject);
    }

}
