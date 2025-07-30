using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{other.name} collided with: {gameObject.name}");
            Debug.Log("Coin Gained");
            
        }
    }
}
