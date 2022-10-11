using UnityEngine;

public class EndLevelZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
