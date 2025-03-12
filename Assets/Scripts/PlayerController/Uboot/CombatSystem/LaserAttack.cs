using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    [SerializeField] private GameObject laserTransform;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject laserSpawn;
    
    private float timer;

    public float coolDown;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
    }

    public void Attack()
    {
   
            if (timer <= 0)
            {
                Instantiate(laser, laserTransform.transform.position, laserSpawn.transform.rotation);
                timer = coolDown;
            }    
            
    }

  
}
