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

        UbootController controller = other.GetComponent<UbootController>();
        
        if (!controller.hasDivingBell)
        {
            return;
        }
        
        this.hudInstance.ShowModal();
        controller.Disablefunctions();
    }
}