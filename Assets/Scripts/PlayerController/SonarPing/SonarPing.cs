using UnityEngine;
using UnityEngine.U2D;

public class SonarPing : MonoBehaviour
{
    public GameObject sonarSpawn;
    public GameObject sonarPing;
    private GameObject currentSonarPing;



    public float coolDown;

    private float timer;

    public float sonarPingDuration;

    


    

    //Timer for bomb
    private void Update()
    {

        Destroy(currentSonarPing, sonarPingDuration);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {  
            Sonarping();
        }
    }

    //Creation of Bomb with a cooldown
    public void Sonarping()
    {
        

        if (timer <= 0)
        {
            currentSonarPing = Instantiate(sonarPing, sonarSpawn.transform.position, Quaternion.identity);
            timer = coolDown;

            ExpansiveWave();
        }

    }

    void ExpansiveWave()
    {
      
    }  
}
