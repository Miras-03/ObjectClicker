using ObserverPattern.GameOver;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void Restart() => SceneManager.LoadScene(0);
}
