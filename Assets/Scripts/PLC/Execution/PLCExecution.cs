using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLCExecution : MonoBehaviour
{
    //we will start with 1 rung
    // Start is called before the first frame update
    public GameObject Parent;
    public List<RungComponent> MainRungs;
    public bool isRunning;
    public Sprite pause;
    public Sprite start;
    public Image RunButtonImage;
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
        if (!isRunning)
        {
            foreach (Transform child in Parent.transform)
            {
                RungComponent comp = child.GetComponent<RungComponent>();
                comp.SetInitialSignal(true);
                if (!MainRungs.Contains(comp)) MainRungs.Add(comp);

            }
            isRunning = true;
            RunButtonImage.sprite = pause;
        }
        else
        {
            isRunning = false;
            RunButtonImage.sprite = start;
        }


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
