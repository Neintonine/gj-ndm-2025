
using UnityEngine;

public class UbootMovement : MonoBehaviour
{
    public GameObject laserRotation;

    public Rigidbody2D rb;


    //Movement of the Uboot
    public void Movement(float speed)
    {
        //Animation left!

        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(movementX, movementY).normalized;

        rb.AddForce(movement * speed, ForceMode2D.Force);


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

}
