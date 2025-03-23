using UnityEngine;

public class DivingBell : MonoBehaviour

{

    private bool isAttached = false;
    private bool isAtUboot = false;

    public GameObject chainPrefab;
    private GameObject ChainTop;
    private GameObject ChainDown;
    [SerializeField] private Boss boss;
    [SerializeField] private GameObject turtle;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isAttached)
        {
            this.AttachChain(other.gameObject.GetComponent<Rigidbody2D>());
            
            this.FreeWay();
            this.StartBossFight();
        }
    }

    private void StartBossFight()
    {
        this.boss.enabled = true;
    }

    private void FreeWay()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("wall"))
        {
            o.SetActive(false);
        }
        
        this.turtle.gameObject.SetActive(false);
    }


    void AttachChain(Rigidbody2D target)
    {

        isAttached = true;

        GameObject chainInstance = Instantiate(chainPrefab, transform.position, Quaternion.identity);
        this.ChainTop = chainInstance.transform.GetChild(0).gameObject;
        this.ChainDown = chainInstance.transform.GetChild(chainInstance.transform.childCount - 1).gameObject;

        HingeJoint2D topJoint = this.ChainTop.GetComponent<HingeJoint2D>();
        topJoint.connectedBody = target;
        
        this.transform.SetParent(this.ChainDown.transform);
        this.transform.localPosition = Vector3.zero;

        HingeJoint2D joint = this.gameObject.AddComponent<HingeJoint2D>();
        joint.connectedBody = this.ChainDown.GetComponent<Rigidbody2D>();
        joint.useLimits = true;
        joint.limits = new JointAngleLimits2D
        {
            min = 0,
            max = 180,
        };
    }
}










