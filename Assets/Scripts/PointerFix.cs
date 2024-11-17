using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 adjustedPosition = Input.mousePosition;

        // Correct for browser scaling
        adjustedPosition.x *= Screen.width / (float)Screen.currentResolution.width;
        adjustedPosition.y *= Screen.height / (float)Screen.currentResolution.height;

        Debug.Log($"Adjusted Mouse Position: {adjustedPosition}");
    }
}
