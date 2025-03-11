using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 8f;
    public float floatForce = 10f;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    public Rigidbody body;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);

        spriteRenderer.flipX = input < 0f; 

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.linearVelocity = Vector2.up * floatForce;
        }
        if (Input.GetKeyDown(KeyCode.E))
        { 
            Destroy(gameObject);
            CameraController.instance.resetFollowingTransform();
        }
        
    
    }
  

}
