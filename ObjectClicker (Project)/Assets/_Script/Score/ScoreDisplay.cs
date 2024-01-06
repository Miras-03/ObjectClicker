using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour, IScoreObserver
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int scoreCount;

    private void Start() => UpdateScore();

    public void ExecuteIncrease() => UpdateScore();

    public void ExecuteDecrease() => UpdateScore();

    private void UpdateScore()
    {
        scoreCount = ScoreSingleton.Instance.Score;
        scoreText.text = $"Score: {scoreCount}";
    }
}