using UnityEngine;

public class DivingBell : MonoBehaviour

{

    private bool isAttached = false;
    private bool isAtUboot = false;

    public GameObject chainPrefab;
    public GameObject ChainTop;
    public GameObject ChainDown;
    public Transform attachPoint;

    void Start()
    {





    }

    private void OnCollisionEnter2D(Collision2D other)
    {



        if (other.gameObject.tag == "Drone" && !isAttached)

        {

            AttachChain(other.transform);

        }

        if (other.gameObject.CompareTag("Player") && isAttached)
        {

            AttachToUboot(other.transform);

        }

    }


    void AttachChain(Rigidbody2D droneRb)
    {

        isAttached = true;



        ChainTop = Instantiate(chainPrefab, attachPoint.position, Quaternion.identity);



        HingeJoint2D droneJoint = droneRb.gameObject.AddComponent<HingeJoint2D>();

        droneJoint.connectedBody = ChainTop.GetComponent<Rigidbody2D>();



        HingeJoint2D belljoint = gameObject.AddComponent<HingeJoint2D>();

        belljoint.connectedBody = ChainDown.GetComponent<Rigidbody2D>();

    }



    void AttachToUboot(Rigidbody2D ubootRb)

    {

        isAtUboot = true;



        HingeJoint2D droneJoint = ChainTop.GetComponent<HingeJoint2D>();



        if (droneJoint != null)

        {

            Destroy(droneJoint);

        }



        HingeJoint2D ubootJoint = ChainTop.AddComponent<HingeJoint2D>();

        ubootJoint.connectedBody = ubootRb;







    }



}










