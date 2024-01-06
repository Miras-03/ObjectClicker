public sealed class ScoreSingleton : IScoreObserver
{
    private static ScoreSingleton instance;

    public ScoreSingleton() => Score = 0;

    public void ExecuteIncrease() => Score++;

    public void ExecuteDecrease() => Score -= 5;

    public static ScoreSingleton Instance
    {
        get
        {
            if (instance == null)
                instance = new ScoreSingleton();
            return instance;
        }
    }

    public int Score { get; private set; }
}