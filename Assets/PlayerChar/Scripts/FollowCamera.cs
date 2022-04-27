using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject FollowTarget;
    public float Distance;

    private float _startingHeight;
    private float _distToGround;

    private void Start()
    {
        _startingHeight = transform.position.y;
        _distToGround = FollowTarget.GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {
          transform.position = new Vector3(FollowTarget.transform.position.x - Distance, FollowTarget.transform.position.y + _startingHeight, FollowTarget.transform.position.z);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(FollowTarget.transform.position, -Vector3.up, _distToGround + 0.1f);
    }
}
