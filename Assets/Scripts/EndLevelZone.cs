using UnityEngine;

public class EndLevelZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
