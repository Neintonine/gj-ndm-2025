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




    //Timer for Sonar
    private void Update()
    {
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

    }

    //Creation of Sonar with a cooldown
    public void Sonarping()
    {
        

        if (timer <= 0)
        {
            currentSonarPing = Instantiate(sonarPing, sonarSpawn.transform.position, Quaternion.identity);

            currentSonarPing.transform.SetParent(sonarSpawn.transform);

            Destroy(currentSonarPing, sonarPingDuration);
            
            timer = coolDown;
        }

    }




}
