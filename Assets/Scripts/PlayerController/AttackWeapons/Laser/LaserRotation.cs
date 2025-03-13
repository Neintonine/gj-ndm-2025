using UnityEngine;

public class LaserRotation : MonoBehaviour
{

    [SerializeField] private new Camera camera;

    [SerializeField] private float initalAngle;

    public void Update()
    {

        Vector3 targetRotation = camera.ScreenToWorldPoint(Input.mousePosition);

        float angleR = Mathf.Atan2(targetRotation.y - transform.position.y, targetRotation.x - transform.position.x);

        float angleD = (180 / Mathf.PI) * angleR - initalAngle;

        transform.rotation = Quaternion.Euler(0,0,angleD);
    }

}
