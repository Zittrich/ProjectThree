using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpacityController : MonoBehaviour
{
    public static int OpacityID = Shader.PropertyToID("_Opacity");

    private float _currentOpacity = 1;

    [Range(0,1)]public float MinimumOpacity;
    public GameObject FollowPoint;
    public Material WallMaterial;
    public LayerMask Mask;

    private Vector3 _fadeOutRelation = new Vector3(0,0,0);

    [HideInInspector] public Camera Camera;

    void Start()
    {
        Camera = Manager.Use<PlayerManager>().MainCamera;
    }

    void FixedUpdate()
    {
        var dir = Camera.transform.position - FollowPoint.transform.position;
        var ray = new Ray(FollowPoint.transform.position, dir.normalized);

        if (GetComponent<Renderer>().isVisible && Manager.Use<PlayerManager>().Player.transform.position.sqrMagnitude - transform.position.sqrMagnitude < _fadeOutRelation.sqrMagnitude)
        {
            _currentOpacity -= Time.deltaTime;
            _currentOpacity = Mathf.Clamp(_currentOpacity, MinimumOpacity, 1);
            WallMaterial.SetFloat(OpacityID, _currentOpacity);
        }

        else
        {
            _currentOpacity += Time.deltaTime;
            _currentOpacity = Mathf.Clamp(_currentOpacity, MinimumOpacity, 1);
            WallMaterial.SetFloat(OpacityID, _currentOpacity);
        }
    }
}
