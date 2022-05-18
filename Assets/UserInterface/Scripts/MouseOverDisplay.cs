using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseOverDisplay : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;

    private Camera _camera;
    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("ViewCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        gameObject.transform.position = _camera.ViewportPointToRay(Input.mousePosition).origin;
    }
}
