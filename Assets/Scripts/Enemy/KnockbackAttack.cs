using UnityEngine;

public class KnockbackAttack : MonoBehaviour
{
    public float knockbackPower = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Knockback(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
    private void Knockback(Rigidbody2D body)
    {
        Vector2 knockbackDirection = body.transform.position - transform.position;
        knockbackDirection.Normalize();
        body.linearVelocity = knockbackDirection * knockbackPower;
    }
}
