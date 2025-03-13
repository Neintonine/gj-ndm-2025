using UnityEngine;

public class StunAttack : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float stunDuration;
    public float knockbackPower;

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement.stunCounter = stunDuration;

    }
}
