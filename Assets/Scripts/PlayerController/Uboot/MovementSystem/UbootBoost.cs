using Unity.VisualScripting;
using UnityEngine;

public class UbootBoost : MonoBehaviour
{

    public UbootController ubootController;

    private float timer;
    public float cooldown = 10;
    public float duration = 5;
    private float boostInventory = 3;


    //Timer for boost
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    //Start of Boost with a cooldown
    public void boost()
    {
        if (timer <= 0 && boostInventory > 0)
        {
            timer = cooldown;

            boostInventory -= 1;

            ubootController.speed = 10;

            Invoke("stopBoost", 5);
        }
    }

    void stopBoost()
    {
        ubootController.speed = 5;
    }

}
