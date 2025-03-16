using System.Collections;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UIElements;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public float speed = 1f;
    public float detectionDistance = 4f;
    private float distance;
    public Health health;
    public float stopDistance = 2f;
    public float attackCooldown = 2f;

    public bool stopChasing = false;



    private void Health_OnDeath()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        health.OnDeath += Health_OnDeath;
        transform.position = spawnPoint.transform.position;
    }


    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Transform target = player.transform;

        if (stopChasing)
        {
            return;
        }

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
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            health.Takedamage(10);
        }

        if (collision.gameObject.tag == "Player")
        {                     
            StartCoroutine(damagecooldown(attackCooldown));
        }
    }



    IEnumerator damagecooldown(float damagecooldown)
    {
        stopChasing = true;
        yield return new WaitForSeconds(damagecooldown);
        stopChasing = false;

    }

}
