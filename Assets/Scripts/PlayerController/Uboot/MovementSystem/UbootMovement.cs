
using UnityEngine;

public class UbootMovement : MonoBehaviour
{
    public GameObject laserRotation;
    
    //Movement of the Uboot
    public void movement(float speed)
    {
        //Animation left!

        //Rotation of sprite left!

        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(movementY, (-movementX));

        transform.Translate(movement * speed * Time.deltaTime);



        if (movementX < 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
            laserRotation.transform.localScale = new Vector3(1,-1,1);
        }
        else if (movementX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            laserRotation.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            laserRotation.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }





}
