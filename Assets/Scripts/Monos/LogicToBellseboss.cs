public class LogicToBellseboss
{
    private readonly IBellsebossCharacter _bellseboss;
    private float deltaLocal;
    private float fireInSeconds;
    private bool isStartToCount;

    public LogicToBellseboss(IBellsebossCharacter bellseboss)
    {
        _bellseboss = bellseboss;
        fireInSeconds = _bellseboss.GetRandom();;
        isStartToCount = true;
    }

    public void Fire(float deltaTime)
    {
        if (!isStartToCount) return;
        deltaLocal += deltaTime;
        if (!(deltaLocal >= fireInSeconds)) return;
        deltaLocal = 0;
        FireToEmployee();
        fireInSeconds = _bellseboss.GetRandom();
    }

    private void FireToEmployee()
    {
        _bellseboss.FireObject();
    }

    public void StartToCount()
    {
        isStartToCount = true;
    }

    public void StopToCount()
    {
        isStartToCount = false;
        deltaLocal = 0;
    }
}