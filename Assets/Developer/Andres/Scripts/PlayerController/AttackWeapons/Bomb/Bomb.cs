using UnityEngine;

public class Bomb : MonoBehaviour
{
    

    //Destruction of Bomb after Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Animation left!
        if (collision.gameObject.tag == "wall")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
}
