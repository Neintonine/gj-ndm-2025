using System;
using System.Collections;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UIElements;

public class AIChase : MonoBehaviour
{
    public float speed = 1f;
    public float detectionDistance = 4f;
    private float distance;
    public Health health;
    public float stopDistance = 2f;
    public float attackCooldown = 2f;

    public bool stopChasing = false;

    private GameObject player;
    private Vector2 spawnPoint;


    private void Health_OnDeath()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.spawnPoint = transform.position;
    }

    void Start()
    {
        health.OnDeath += Health_OnDeath;
    }


    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 target = player.transform.position;

        if (stopChasing)
        {
            return;
        }

        if (distance > detectionDistance)
        {
            target = this.spawnPoint;
        }
        
        //                    Player       <-    Enemy  
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
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
