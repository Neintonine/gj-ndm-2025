using UnityEngine;
using UnityEngine.UIElements;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public float speed;
    public float distanceBetween;
    private float distance;

    public Health health;
    public int damage;

    void Start()
    {
       transform.position = spawnPoint.transform.position;
    }
   
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        
        Transform target = player.transform;
        if (distance > distanceBetween)
        {
            target = this.spawnPoint.transform;
        }
        //                    Player       <-    Enemy  
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        health.Takedamage(damage);
    }
}
