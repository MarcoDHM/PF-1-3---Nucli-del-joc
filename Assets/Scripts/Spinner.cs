using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private float floatSpeed = 2f;
    [SerializeField] private float floatDistance = 0.25f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);

        float newY = initialPosition.y + Mathf.PingPong(Time.time * floatSpeed, floatDistance);
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
