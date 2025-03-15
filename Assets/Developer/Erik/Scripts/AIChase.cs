using UnityEngine;
using UnityEngine.UIElements;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public float speed = 1;
    public float detectionDistance = 4;
    private float distance;
    public float attackRange = 2;
    public Health health;


    void Start()
    {
        transform.position = spawnPoint.transform.position;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Transform target = player.transform;
        if (distance > detectionDistance)
        {
            target = this.spawnPoint.transform;
        }
        //                    Player       <-    Enemy  
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        // Test
        //if (distance <= attackRange)
        //    speed = 0;
        //else
        //    speed = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            health.Takedamage(10);
        }
    }
}
