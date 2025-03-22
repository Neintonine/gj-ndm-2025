using System;
using UnityEngine;

public sealed class DestructableWall : MonoBehaviour
{
    private Collider2D _collider2D;
    private Rigidbody2D[] _rigidbodies;
    
    private void Awake()
    {
        _rigidbodies = this.GetComponentsInChildren<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    public void Collapse()
    {
        foreach (Rigidbody2D rigidbody in this._rigidbodies)
        {
            rigidbody.WakeUp();
        }
        
        _collider2D.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Bomb"))
        {
            return;
        }
        
        Collapse();
    }
}