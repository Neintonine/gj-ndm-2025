using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] private ParticleSystem bombExplosion;

    private ParticleSystem currentBombExplosion;

    private void Start()
    {
        Destroy(this.gameObject, 5);
    }

    //Destruction of Bomb after Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Animation left!
        if (collision.gameObject.tag == "wall")
        {
            Bombexplosion();
            Destroy(gameObject);
        }        
    }



    private void Bombexplosion()
    {
        currentBombExplosion = Instantiate(bombExplosion,transform.position, Quaternion.identity);
    }
}
