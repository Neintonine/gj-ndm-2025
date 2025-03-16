using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    public Health health;
    
    void Start()
    {
        health.OnDeath += Health_OnDeath;
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        transform.position = pointA.transform.position;
    }

    
    void Update()
    {
        Vector2 direction = currentPoint.position - transform.position;
        direction.Normalize();
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, currentPoint.transform.position, speed * Time.deltaTime);
        transform.right = direction;

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {            
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {            
            currentPoint = pointB.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            health.Takedamage(10);
        }
    }
    private void Health_OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
