using UnityEngine;



public class UbootController : MonoBehaviour
{
    [SerializeField] float speed;

    

    public BombAttack bombAttack;
    public UbootMovement ubootMovement;
    public LaserAttack laserAttack;
    public DroneDeploy droneDeploy;
    public SonarPing sonarPing;

    void Update()
    {
        Movement(speed);
        Bombattack();
        LaserAttack();
        dronedeploy();
        
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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


}
