using UnityEngine;

public sealed class Food : MonoBehaviour
{
    private Rigidbody rb;

    private const int startPos = -6;
    private const int xRange = 4;
    private const int minSpeed = 12;
    private const int maxSpeed = 16;
    private const int maxTorque = 10;


    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Start()
    {
        SetStartPos();
        TossUp();
    }

    private void OnMouseDown() => Destroy(gameObject);

    private void OnCollisionEnter() => Destroy(gameObject);

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