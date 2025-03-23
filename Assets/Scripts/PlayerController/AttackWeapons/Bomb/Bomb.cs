using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] private ParticleSystem bombExplosion;
    [SerializeField] private AudioSource audioSource;
    
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
            this.audioSource.Play();
            Destroy(gameObject, 20);
        }        
    }



    private void Bombexplosion()
    {
        currentBombExplosion = Instantiate(bombExplosion,transform.position, Quaternion.identity);
    }
}
