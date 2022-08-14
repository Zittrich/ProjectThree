using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

   public Material WallMaterial;
    [HideInInspector] public Camera Camera;
    public LayerMask Mask;
    public GameObject FollowPoint;

    private float _currentSize;

    private void Start()
    {
        Camera = Manager.Use<PlayerManager>().MainCamera;
    }

    private void FixedUpdate()
    {
        var dir = Camera.transform.position - FollowPoint.transform.position;
        var ray = new Ray(FollowPoint.transform.position, dir.normalized);

        if (Physics.Raycast(ray, 30000, Mask))
        {
            _currentSize += Time.deltaTime;
            _currentSize = Mathf.Clamp(_currentSize, 0, 1.2f);
            WallMaterial.SetFloat(SizeID, _currentSize);
        }

        else
        {
            _currentSize -= Time.deltaTime;
            _currentSize = Mathf.Clamp(_currentSize, 0, 1.2f);
            WallMaterial.SetFloat(SizeID, _currentSize);
        }

        var view = Camera.WorldToViewportPoint(FollowPoint.transform.position);
        WallMaterial.SetVector(PosID, view);

    }
}
