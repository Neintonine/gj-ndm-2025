using System.Collections;
using UnityEngine;

public class StunAttack : MonoBehaviour
{

    public float stunDuration;
    public UbootController ubootController;
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {           
            StartCoroutine(stunTimer(stunDuration));           
        }
    }

    IEnumerator stunTimer(float stunDuration)
    {
        ubootController.Disablefunctions();
        yield return new WaitForSeconds(stunDuration);
        ubootController.Enablefuctions();
    }
}
