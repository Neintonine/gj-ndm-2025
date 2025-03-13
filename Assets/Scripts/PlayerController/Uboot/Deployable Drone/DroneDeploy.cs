using UnityEngine;

public class DroneDeploy : MonoBehaviour
{
    

    public GameObject droneSpawm;
    public GameObject drone;
    public CameraController cameraController;

    public GameObject currentDrone;



    //Deployment of Drone --> only deploy if there are no more drones
    public void Dronedeploy()
    {
        //Animation maybe?
        if (currentDrone == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Createdrone();
            }
        }
    }


    //Creation of Drone
    public void Createdrone()
    {
        currentDrone = Instantiate(drone, droneSpawm.transform.position, Quaternion.identity);
        this.cameraController.setFollowingTransform(this.currentDrone.transform);
    }


}
