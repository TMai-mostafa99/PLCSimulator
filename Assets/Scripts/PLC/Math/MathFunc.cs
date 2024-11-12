public class MathFunc : PLCComponent
{


    protected bool previousSignal;

    public SignalData EN;
    public SignalData ENO;
    public SignalData Num1;
    public SignalData Num2;
    public SignalData OUT;


    protected override void Start()
    {
        base.Start();
        EN = new SignalData(VarTypes.BOOL, "EN", false, 0, false);
        ENO = new SignalData(VarTypes.BOOL, "ENO", false, 0, false);
        Num1 = new SignalData(VarTypes.NUMBER, "Num1", false, 0, true);
        Num2 = new SignalData(VarTypes.NUMBER, "Num2", false, 0, true);
        OUT = new SignalData(VarTypes.NUMBER, "OUT", false, 0, false);

        Data.Add(Num1);
        Data.Add(Num2);
        Data.Add(OUT);
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        EN.Signal = SignalIn.Signal = RungSignal.Signal;
        ENO.Signal = SignalOut.Signal = EN.Signal;
    }
}
