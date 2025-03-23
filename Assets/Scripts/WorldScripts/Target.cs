using System;
using UnityEngine;

public sealed class Target : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("DivingBell"))
        {
            return;
        }
        
        Debug.Log("Game Complete");
    }
}