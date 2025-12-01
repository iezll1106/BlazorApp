public class PizzaSalesState
{
    public int PizzasSoldToday { get; set; } = 0;

    public event Action OnChange;

    public void Increment()
    {
        PizzasSoldToday++;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}