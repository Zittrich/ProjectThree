using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject FollowTarget;
    public Vector3 Offset;
    [Range(0, 360)]public float Rotation;

    private void Start()
    {

    }
    private void FixedUpdate()
    {

        Offset.x -= Input.mouseScrollDelta.x;
        Offset.x += Input.mouseScrollDelta.y;

        Offset.y += Input.mouseScrollDelta.x;
        Offset.y -= Input.mouseScrollDelta.y;

        Offset.z -= Input.mouseScrollDelta.x;
        Offset.z += Input.mouseScrollDelta.y;

        transform.position = new Vector3(
              FollowTarget.transform.position.x + Offset.x, 
              FollowTarget.transform.position.y + Offset.y,
              FollowTarget.transform.position.z + Offset.z
              );

        transform.LookAt(FollowTarget.transform.position);
        transform.Rotate(FollowTarget.transform.position, Rotation);
    }
}
