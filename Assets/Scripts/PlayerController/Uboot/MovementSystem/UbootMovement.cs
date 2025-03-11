using Codice.CM.Common;
using UnityEngine;

public class UbootMovement : MonoBehaviour
{
    public GameObject bombSpawn;
    
    //Movement of the Uboot
    public void movement(float speed)
    {
        //Animation left!

        //Rotation of sprite left!

        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(movementY, (-movementX));

        transform.Translate(movement * speed * Time.deltaTime);



        //if (movementX > 0)
        //{

        //    bombSpawn.transform.position = new Vector3(3 / 2, 0, 2 );
        //}
        //else if (movementX < 0 )
        //{
            
         //   turnAround();
        //}
    }

    private void turnAround()
    {

        bombSpawn.transform.position = new Vector3(-3 / 2, 0, 2);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }





}
