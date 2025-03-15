using UnityEngine;

public class KnockbackAttack : MonoBehaviour
{
    public Rigidbody2D player;
    public float knockbackPower = 200;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Knockback();
        }
    }
    private void Knockback()
    {
        Vector2 knockbackDirection = player.transform.position - transform.position;
        knockbackDirection.Normalize();
        player.linearVelocity = knockbackDirection * knockbackPower * Time.deltaTime;
    }
}
