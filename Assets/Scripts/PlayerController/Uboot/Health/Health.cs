using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int InitialHealth { get; private set; }
    
    public int health;
    public event Action OnDeath;
    public event Action<int> OnHealthChange;
    public event Action OnDamage;

    private void Awake()
    {
        InitialHealth = this.health;
    }

    public void Takedamage(int damage)
    {
        health -= damage;
        OnHealthChange?.Invoke(this.health);
        if (damage > 0)
        {
            OnDamage?.Invoke();
        }

        if (health <= 0)
        {
            this.OnDeath?.Invoke();
        }
    }
}
