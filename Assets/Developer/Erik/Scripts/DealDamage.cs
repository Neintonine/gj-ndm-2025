using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public Health health;
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.Takedamage(damage);
        }
    }
}
