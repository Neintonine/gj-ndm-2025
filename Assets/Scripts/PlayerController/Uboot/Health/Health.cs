using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public void Takedamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
