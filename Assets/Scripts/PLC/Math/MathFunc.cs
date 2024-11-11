public class MathFunc : PLCComponent
{

    public bool EN;
    public bool ENO;
    public int Num1;
    public int Num2;
    public int OUT;
    protected bool previousSignal;

    // Update is called once per frame
    void Update()
    {
        EN = SignalIn.Signal = RungSignal.Signal;
        ENO = SignalOut.Signal = EN;
    }
}
