using System;
using UnityEngine;

public sealed class StuckTurtle : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Drone"))
        {
            return;
        }
        
        float hitDirection = Vector2.Dot(transform.up, other.contacts[0].normal);
        Debug.Log(hitDirection);
        
        if (hitDirection < 0.9)
        {
            return;
        }
        
        _animation.Play("StuckTurtleFreeAnimation");
    }
}
    