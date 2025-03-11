using UnityEngine;

public class DroneDeploy : MonoBehaviour
{
    

    public GameObject DroneSpawm;
    public GameObject Drone;
    public CameraController CameraController;

    private GameObject currentDrone;

    private bool isdroning;


    //Deployment of Drone --> only deploy if there are no more drones
    public void dronedeploy()
    {
        //Animation maybe?
        if (currentDrone == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                createDrone();
            }
        }

        isDroning(isdroning);
    }

    public void isDroning(bool isDroning)
    {
        if (currentDrone != null)
        {
            isDroning = true;
        }

    }

    //Creation of Drone
    public void createDrone()
    {
        currentDrone = Instantiate(Drone, DroneSpawm.transform.position, Quaternion.identity);
        this.CameraController.setFollowingTransform(this.currentDrone.transform);
    }


}
