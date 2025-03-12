using UnityEngine;
using UnityEngine.U2D;

public class SonarPing : MonoBehaviour
{

    public UbootController ubootController;
    public GameObject sonarSpawn;
    public GameObject sonarPing;
    private GameObject currentSonarPing;

    public GameObject capsuleRenderer;

    public float coolDown = 10;

    private float timer;

    public float sonarPingDuration = 5;


    //Timer for bomb
    private void Update()
    {
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

    }

    //Creation of Bomb with a cooldown
    public void Sonarping()
    {
        

        if (timer <= 0)
        {
            currentSonarPing = Instantiate(sonarPing, sonarSpawn.transform.position, Quaternion.identity);


            Destroy(currentSonarPing, sonarPingDuration);
            
            timer = coolDown;

            Invoke("returnColor", sonarPingDuration);

        }

    }




}
