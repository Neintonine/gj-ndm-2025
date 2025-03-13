using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public static CameraController instance;

    public float followSpeed = 10;

    public GameObject Uboot;
    
    private Transform _followingTransform;

    private void Start()
    {
        _followingTransform = Uboot.transform;
        instance = this;
    }

    private void Update()
    {
        Vector3 newPos = new Vector3(this._followingTransform.position.x, this._followingTransform.position.y, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    public void setFollowingTransform(Transform followingTransform)
    {
        _followingTransform = followingTransform;
    }

    public void resetFollowingTransform()
    {
        _followingTransform = Uboot.transform;
    }
}
