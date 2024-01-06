using UnityEngine;
using ObserverPattern.Score;
using ObserverPattern.GameOver;

public sealed class Food : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    private UIManager gameManager;
    private Rigidbody rb;

    [SerializeField] private int point = 5;
    private const int startPos = -6;
    private const int xRange = 4;
    private const int minSpeed = 12;
    private const int maxSpeed = 16;
    private const int maxTorque = 10;

    private void Awake()
    {
        gameManager = FindObjectOfType<UIManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetStartPos();
        TossUp();
    }

    private void OnMouseDown()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Score.Instance.Notify(point);
        Destroy(gameObject);
    }

    private void OnCollisionEnter() => Destroy(gameObject);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
            GameOver.Instance.Notify();
    }

    private void SetStartPos() => transform.position = new Vector3(RandomWidth(), startPos);

    private void TossUp()
    {
        rb.AddForce(Vector2.up * RandomSpeed(), ForceMode.Impulse);
        rb.AddTorque(RandomCeiling(), RandomCeiling(), RandomCeiling(), ForceMode.Impulse);
    }

    private int RandomWidth() => Random.Range(-xRange, xRange);

    private int RandomSpeed() => Random.Range(minSpeed, maxSpeed);

    private int RandomCeiling() => Random.Range(-maxTorque, maxTorque);
}