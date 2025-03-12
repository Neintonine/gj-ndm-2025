using System;
using UnityEngine;



public class UbootController : MonoBehaviour
{
    public float speed;

    

    public BombAttack bombAttack;
    public UbootMovement ubootMovement;
    public LaserAttack laserAttack;
    public DroneDeploy droneDeploy;
    public SonarPing sonarPing;
    public UbootBoost ubootBoost;
    public Health health;



    void Update()
    {
        Movement(speed);
        Bombattack();
        LaserAttack();
        dronedeploy();
        sonarPulse();
        activeBoost();
    }


    //Movement of the Uboot "WASD"
    void Movement(float speed)
    {
        ubootMovement.movement(speed);
    }


    //BombAttack with SpaceBar
    void Bombattack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bombAttack.bombAttack();
        }
    }


    //LaserAttack with left Click
    void LaserAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            laserAttack.Attack();
        }
        
    }


    //DroneDeploy with E
    void dronedeploy()
    {
        droneDeploy.dronedeploy();
    }


    //SonarPulse with R
    void sonarPulse()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sonarPing.Sonarping();
        }
    }

    //Boost with G
    void activeBoost()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ubootBoost.boost();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyAttack")
        {
            health.health -= 30;

            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            bombAttack.pickupBomb();

            Destroy(collision.gameObject);
        }
    }


}
