using System;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public GameObject bomb;
    public GameObject bombSpawn;


    public int bombInventory = 0;    

    public float coolDown;

    private float timer;

    public event Action<int> BombInventoryChanged;

    private void Start()
    {
        BombInventoryChanged?.Invoke(this.bombInventory);
    }


    //Timer for bomb
    private void Update()
    {
        if (timer > 0 )
        {
            timer -= Time.deltaTime;
        }
    }

    //Creation of Bomb with a cooldown
    public void Bombattack()
    {
        if (timer <= 0 && bombInventory > 0)
        {
            Instantiate(bomb, bombSpawn.transform.position, Quaternion.identity);

            timer = coolDown;

            bombInventory -= 1;
            BombInventoryChanged?.Invoke(this.bombInventory);
        }
        
    }

    public void Pickupbomb()
    {
        bombInventory += 1;
        BombInventoryChanged?.Invoke(this.bombInventory);
    }

}
