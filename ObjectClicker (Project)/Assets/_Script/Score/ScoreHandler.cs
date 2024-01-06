using UnityEngine;

public sealed class ScoreHandler : MonoBehaviour
{
    [SerializeField] private ScoreDisplay scoreDisplay;

    private void OnEnable()
    {
        AddObserver(scoreDisplay);
        AddObserver(ScoreSingleton.Instance);
    }

    private void AddObserver(IScoreObserver observer) => Score.Instance.Add(observer);
}
