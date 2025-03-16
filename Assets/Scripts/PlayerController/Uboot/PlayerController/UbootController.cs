using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class UbootController : MonoBehaviour
{
    
    public BombAttack bombAttack;
    public UbootMovement ubootMovement;
    public LaserAttack laserAttack;
    public DroneDeploy droneDeploy;
    public SonarPing sonarPing;
    public UbootBoost ubootBoost;
    public Health health;
    public LaserRotation laserRotation;

    public float speed = 5f;
    public bool stun;

    private void Health_OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        health.OnDeath += Health_OnDeath;    
    }

    void Update()
    {
        //Movement "WASD"
        ubootMovement.Movement(speed);

        //Bomb Attack Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bombAttack.Bombattack();
        }

        //Laser Attack left click mouse
        if (Input.GetMouseButtonDown(0))
        {
            laserAttack.Attack();
        }

        //Drone Deploy E
        droneDeploy.Dronedeploy();

        //Sonar Ping R
        if (Input.GetKeyDown(KeyCode.R))
        {
            sonarPing.Sonarping();
        }

        //Speedboost G
        if (Input.GetKeyDown(KeyCode.G))
        {
            ubootBoost.Boost();
        }

        if (droneDeploy.currentDrone != null)
        {
            Disablefunctions();
        }

    }

    //Disable all Functions of Uboot
    public void Disablefunctions()
    {
        this.enabled = false;

        this.laserRotation.enabled = false;        
    }

    //Enable all Functions of Uboot
    public void Enablefuctions()
    {
        this.enabled = true;

        this.laserRotation.enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            bombAttack.Pickupbomb();

            Destroy(collision.gameObject);
        }        
    }
}
