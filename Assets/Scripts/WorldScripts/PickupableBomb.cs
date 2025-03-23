using System;
using UnityEngine;

public sealed class PickupableBomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Drone"))
        {
            return;
        }
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<BombAttack>().Pickupbomb();
        Destroy(gameObject);
    }
}