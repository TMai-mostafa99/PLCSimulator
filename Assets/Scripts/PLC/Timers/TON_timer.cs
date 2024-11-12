using UnityEngine;

public class TON_timer : Timer
{

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (IN) // timer started
        {
            ET += (int)Time.deltaTime;

            if(ET >= PT)
            {
                Q = SignalOut = true;
            }
            else
            {
                Q = SignalOut = false;
            }
        }
    }
}
