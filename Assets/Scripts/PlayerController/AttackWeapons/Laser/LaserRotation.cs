using UnityEngine;

public class LaserRotation : MonoBehaviour
{

    [SerializeField] private new Camera camera;

    [SerializeField] private float initalAngle;

    private Transform laserTransform;
    private Collider2D ubootCollider;



    private void Awake()
    {
        laserTransform = gameObject.transform.GetChild(0).GetComponent<Transform>();

        ubootCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<PolygonCollider2D>();
        camera ??= GameObject.FindWithTag("MainCamera").GetComponentInChildren<Camera>();
    }
    
    public void Update()
    {
        this.DirectLookAtCursor();
    }

    private void DirectLookAtCursor()
    {
        this.laserTransform.position = transform.position;
        
        Vector3 targetPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (targetPosition - laserTransform.position).normalized;
        this.transform.right = direction;
    }

    private void AttachedToCollider()
    {
        Vector3 targetRotation = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 closestPoint = ubootCollider.ClosestPoint(targetRotation);

        Vector2 direction = (targetRotation - (Vector3)closestPoint).normalized;

        float angleR = Mathf.Atan2(direction.y, direction.x);

        float angleD = Mathf.Rad2Deg * angleR - initalAngle;

        transform.rotation = Quaternion.Euler(0,0,angleD);

        laserTransform.position = closestPoint;
    }
    
}
