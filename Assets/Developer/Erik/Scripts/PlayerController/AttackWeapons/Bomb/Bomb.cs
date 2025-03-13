using UnityEngine;

public class Bomb : MonoBehaviour
{

    //Destruction of Bomb after Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);

        //Animation left!
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }        
    }
}
