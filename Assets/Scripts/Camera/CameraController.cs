using UnityEngine;

public class CameraController : MonoBehaviour
{
   

    public float followSpeed;

    public GameObject Uboot;

    public GameObject drone;

    private bool isDroning;

    private void Update()
    {
        ubootFollow();
    }

    private void ubootFollow()
    {
        Vector3 newPos = new Vector3(Uboot.transform.position.x, Uboot.transform.position.y, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);  
    }


    //Not Ready
    public void droneFollow()
    {
        Vector3 newPos = new Vector3(drone.transform.position.x, drone.transform.position.y, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
