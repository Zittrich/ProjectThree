using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject FollowTarget;
    public Vector3 Offset;

    private void Update()
    {
          transform.position = new Vector3(FollowTarget.transform.position.x + Offset.x, FollowTarget.transform.position.y + Offset.y, FollowTarget.transform.position.z + Offset.z);
    }
}
