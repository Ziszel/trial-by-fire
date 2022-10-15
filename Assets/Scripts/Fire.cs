using System;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().Die();
        }
    }
}
