using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class UbootController : MonoBehaviour
{


    public BombAttack bombAttack;
    public UbootMovement ubootMovement;
    public LaserAttack laserAttack;
    public DroneDeploy droneDeploy;
    public SonarPing sonarPing;
    public UbootBoost ubootBoost;
    public Health health;

    public float speed = 5;
    public bool Stun;

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
    public void Movement(float speed)
    {
        ubootMovement.movement(speed);

        stun();
    }


    //BombAttack with SpaceBar
    public void Bombattack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bombAttack.bombAttack();
        }

        stun();
    }


    //LaserAttack with left Click
    public void LaserAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            laserAttack.Attack();
        }

        stun();

    }


    //DroneDeploy with E
    public void dronedeploy()
    {
        droneDeploy.dronedeploy();

        stun();
    }


    //SonarPulse with R
    public void sonarPulse()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sonarPing.Sonarping();
        }

        stun();
    }

    //Boost with G
    public void activeBoost()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ubootBoost.boost();
        }

        stun();
    }

    public void stun()
    {
        if (Stun)
        {
            this.enabled = false;    
        }  
   
    }

    void stunOff()
    {
        Stun = false;

 
            this.enabled = true;

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

            Stun = true;

            Invoke("stunOff", 2);
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
