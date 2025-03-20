using UnityEngine;


public class Drone : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 8f;
    public float floatForce = 10f;
    private Vector2 movement;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public UbootController UbootControllerDrone;

    public BombAttack BombAttackDrone;

    
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        this.rb.AddForceX(input * speed);
        
        spriteRenderer.flipX = input < 0f; 

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.linearVelocityY = floatForce;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            CameraController.instance.resetFollowingTransform();
            UbootControllerDrone.Enablefuctions();

        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            BombAttackDrone.Pickupbomb();


            Destroy(collision.gameObject);
        }
    }
}
