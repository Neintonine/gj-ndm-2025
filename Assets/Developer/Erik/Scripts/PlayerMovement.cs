using NUnit.Framework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float stunCounter;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (stunCounter <= 0)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            Vector2 direction = new Vector2(moveX, moveY).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.zero);
            stunCounter -= Time.deltaTime;
        }
        
        
    }

}
