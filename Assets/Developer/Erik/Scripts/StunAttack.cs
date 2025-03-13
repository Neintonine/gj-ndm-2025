using UnityEngine;

public class StunAttack : MonoBehaviour
{

    public float stunDuration;
    public UbootController ubootController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        this.ubootController.Disablefunctions();
    }
}
