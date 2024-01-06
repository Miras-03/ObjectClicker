using ObserverPattern.GameOver;
using System.Collections;
using UnityEngine;

public sealed class FoodSpawner : MonoBehaviour, IGameOverObserver
{
    [SerializeField] private Transform[] foods;

    private const int interval = 1;

    private void Start() => StartCoroutine(SpawnWithDelay());

    private IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(interval);
        while (true)
        {
            yield return new WaitForSeconds(interval);
            int randIndex=Random.Range(0,foods.Length);
            Instantiate(foods[randIndex]);
        }
    }

    public void ExecuteGameOver() => StopAllCoroutines();
}