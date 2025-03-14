using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public event Action OnDeath;

    public void Takedamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            this.OnDeath?.Invoke();
        }
    }
}
