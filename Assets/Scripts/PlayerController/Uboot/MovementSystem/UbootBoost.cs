using Unity.VisualScripting;
using UnityEngine;

public class UbootBoost : MonoBehaviour
{

    public UbootController ubootController;

    private float timer;
    public float cooldown = 10;
    private float boostInventory = 3;

    private float speed;
    private float speedBoost;

    private void Awake()
    {
        speedBoost = ubootController.speed;

    }


    //Timer for boost
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    //Working on that
    public void Boost()
    {
        if (timer <= 0 && boostInventory > 0)
        {
            timer = cooldown;

            speed *= 2;

            boostInventory -= 1; 

            Invoke("StopBoost", 5);            
        }
    }

    float StopBoost()
    {
        return speed;
    }

}
