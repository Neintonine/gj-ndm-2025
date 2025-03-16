using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] private ParticleSystem bombExplosion;

    private ParticleSystem currentBombExplosion;

    //Destruction of Bomb after Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);

        //Animation left!
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "Enemy")
        {
            Bombexplosion();
            Destroy(collision.gameObject);
        }        
    }



    private void Bombexplosion()
    {
        currentBombExplosion = Instantiate(bombExplosion,transform.position, Quaternion.identity);
    }
}
