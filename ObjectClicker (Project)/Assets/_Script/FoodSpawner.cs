using ObserverPattern.Start;
using ObserverPattern.GameOver;
using System.Collections;
using UnityEngine;

public sealed class FoodSpawner : MonoBehaviour, IGameOverObserver, IStartObserver
{
    private ObjectPooler objectPooler;

    private void Awake() => objectPooler = GetComponent<ObjectPooler>();

    private void Start() => objectPooler.CreateObject(transform);

    public void ExecuteStart(float rate) => StartCoroutine(SpawnWithDelay(rate));

    public void ExecuteGameOver() => StopAllCoroutines();

    private IEnumerator SpawnWithDelay(float rate)
    {
        yield return new WaitForSeconds(rate);
        while (true)
        {
            yield return new WaitForSeconds(rate);
            objectPooler.GetObject(RandomFood());
        }
    }

    private string RandomFood()
    {
        ObjectTypes[] types = { ObjectTypes.Skull, ObjectTypes.Cookie, ObjectTypes.Steak, ObjectTypes.EnergyCan };
        string type = types[Random.Range(0, types.Length)].ToString();
        return type;
    }

    internal enum ObjectTypes
    {
        Skull,
        Cookie,
        Steak,
        EnergyCan
    }
}