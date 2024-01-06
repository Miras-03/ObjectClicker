using UnityEngine;

namespace ObserverPattern.Start
{
    public sealed class StartHandler : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private FoodSpawner foodSpawner;

        private void OnEnable()
        {
            Add(uiManager);
            Add(foodSpawner);
        }

        private void OnDestroy() => Clear();

        private void Add(IStartObserver obs) => Start.Instance.Add(obs);

        private void Clear() => Start.Instance.Clear();
    }
}