using ObserverPattern.GameOver;
using UnityEngine;

public class UIManager : MonoBehaviour, IGameOverObserver
{
    [SerializeField] private GameObject gameOverPanel;

    private void Start() => GameOver(false);

    public void ExecuteGameOver() => GameOver(true);

    private void GameOver(bool flag) => gameOverPanel.SetActive(flag);
}