using System;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent onCoinGained;
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{other.name} collided with: {gameObject.name}");
            Debug.Log("Coin Gained");
            
            onCoinGained.Invoke();
            Destroy(gameObject);
            
        }
    }
}
