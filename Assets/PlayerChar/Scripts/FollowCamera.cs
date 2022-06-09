using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject FollowTarget;
    public Vector3 Offset;

    private void Update()
    {
          transform.position = new Vector3(FollowTarget.transform.localPosition.x + Offset.x, FollowTarget.transform.localPosition.y + Offset.y, FollowTarget.transform.localPosition.z + Offset.z);
    }
}
