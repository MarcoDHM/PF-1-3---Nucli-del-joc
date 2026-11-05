using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(points);
            }
            Destroy(gameObject);
        }
    }
}
