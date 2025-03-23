using System;
using UnityEngine;

public sealed class Target : MonoBehaviour
{
    [SerializeField] private HUDGameCompletion hudInstance;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (!other.GetComponent<UbootController>().hasDivingBell)
        {
            return;
        }
        
        this.hudInstance.ShowModal();
    }
}