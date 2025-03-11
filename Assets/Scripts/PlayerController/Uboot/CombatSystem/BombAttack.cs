using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public GameObject bomb;
    public GameObject bombSpawn;

    public float coolDown;

    private float timer;

    //Timer for bomb
    private void Update()
    {
        if (timer > 0 )
        {
            timer -= Time.deltaTime;
        }
    }

    //Creation of Bomb with a cooldown
    public void bombAttack()
    {
        if (timer <= 0)
        {
            Instantiate(bomb, bombSpawn.transform.position, Quaternion.identity);
            timer = coolDown;
        }
        
    }
}
