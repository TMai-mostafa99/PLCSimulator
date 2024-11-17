using TMPro;

public class MathFunc : PLCComponent
{


    protected bool previousSignal;

    public SignalData EN;
    public SignalData ENO;
    public SignalData Num1;
    public SignalData Num2;
    public SignalData OUT;

    public TMP_Text AssignedVar1;
    public TMP_Text AssignedVar2;
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
        EN.Signal = SignalIn = RungSignal;
        ENO.Signal = SignalOut = EN.Signal;

        if (AssignedVar1 != null)
        {
            if (addedToRung) AssignedVar1.gameObject.SetActive(true);
            else AssignedVar1.gameObject.SetActive(false);
            AssignedVar1.text = Num1.assignedrow ? Num1.assignedrow.VarName : "???";
        }
        if (AssignedVar2 != null)
        {
            if (addedToRung) AssignedVar2.gameObject.SetActive(true);
            else AssignedVar2.gameObject.SetActive(false);
            AssignedVar2.text = Num2.assignedrow ? Num2.assignedrow.VarName : "???";
        }
    }
}
