using Codice.CM.Common;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody2D rb;

    [SerializeField] private float speedLaser;

    private void Update()
    {
        rb = GetComponent<Rigidbody2D>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;

        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speedLaser;

    }


    //Destruction of Laser after Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Animation left!
            Destroy(gameObject);

        if (collision.gameObject.tag == "Enemy")
        {
            //Animation left!
            Destroy(collision.gameObject);
        }
    }

}
