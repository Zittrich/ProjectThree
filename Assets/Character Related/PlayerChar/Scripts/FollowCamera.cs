using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject FollowTarget;
    public Vector3 Offset;
    [Range(0, 360)]public float Rotation;
    public Vector2 ScrollBounds;

    private void Start()
    {
        FollowTarget.transform.rotation.eulerAngles.Set(FollowTarget.transform.rotation.x, Rotation, FollowTarget.transform.rotation.y);
    }

    private void Update()
    {

        Offset.x -= Input.mouseScrollDelta.x;
        Offset.x += Input.mouseScrollDelta.y;
        Offset.x = Mathf.Clamp(Offset.x, ScrollBounds.y * -1, ScrollBounds.x * -1);

        Offset.y += Input.mouseScrollDelta.x;
        Offset.y -= Input.mouseScrollDelta.y;
        Offset.y = Mathf.Clamp(Offset.y, ScrollBounds.x, ScrollBounds.y);

        Offset.z -= Input.mouseScrollDelta.x;
        Offset.z += Input.mouseScrollDelta.y;
        Offset.z = Mathf.Clamp(Offset.z, ScrollBounds.y * -1, ScrollBounds.x * -1);

        transform.position = new Vector3(
              FollowTarget.transform.position.x + Offset.x, 
              FollowTarget.transform.position.y + Offset.y,
              FollowTarget.transform.position.z + Offset.z
              );

        transform.LookAt(FollowTarget.transform.position);
    }
}
