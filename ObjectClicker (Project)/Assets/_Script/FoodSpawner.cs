using ObserverPattern.Start;
using ObserverPattern.GameOver;
using System.Collections;
using UnityEngine;

public sealed class FoodSpawner : MonoBehaviour, IGameOverObserver, IStartObserver
{
    [SerializeField] private Transform[] foods;

    public void ExecuteStart(float rate) => StartCoroutine(SpawnWithDelay(rate));

    public void ExecuteGameOver() => StopAllCoroutines();

    private IEnumerator SpawnWithDelay(float rate)
    {
        yield return new WaitForSeconds(rate);
        while (true)
        {
            yield return new WaitForSeconds(rate);
            int randIndex = Random.Range(0, foods.Length);
            Instantiate(foods[randIndex]);
        }
    }
}