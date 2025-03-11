using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    [SerializeField] private GameObject laserTransform;
    [SerializeField] private GameObject laser;
    
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
                Instantiate(laser, laserTransform.transform.position, laser.transform.rotation);
                timer = coolDown;
            }    
            
    }

  
}
