
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private float speedLaser = 8;

    private void Update()
    {

        transform.Translate(Vector2.down * speedLaser * Time.deltaTime);

        Destroy(gameObject, 8);
    }


    //Destruction of Laser after Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        Destroy(gameObject);
    }

}
