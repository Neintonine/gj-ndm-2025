using System.Collections;
using Codice.Client.Common.GameUI;
using UnityEngine;

public class StunAttack : MonoBehaviour
{

    public float stunDuration;
    public UbootController ubootController;
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {           
            this.ubootController.Disablefunctions();
            StartCoroutine(stunTimer(stunDuration));           
        }
    }

    IEnumerator stunTimer(float stunDuration)
    {
        yield return new WaitForSeconds(stunDuration);
        ubootController.Enablefuctions();
    }
}
