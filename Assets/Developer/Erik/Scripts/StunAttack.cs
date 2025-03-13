using UnityEngine;

public class StunAttack : MonoBehaviour
{

    public float stunDuration;
    public UbootController ubootController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ubootController.Disablefunctions();
    }
}
