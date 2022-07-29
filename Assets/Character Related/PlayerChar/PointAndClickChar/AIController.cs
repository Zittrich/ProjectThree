using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(PlayerController))]
public class AIController : MonoBehaviour
{
    private PlayerController _controller;
    public Vector3 ScanAngle = new Vector3(0, 0, 90);
    public LayerMask GroundLayer;

    public KeyObject Key;
    public NavMeshAgent Agent;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<PlayerController>();
        Agent = GetComponent<NavMeshAgent>();

        Cursor.visible = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //KeepOnPlatform();
        if(Input.GetKeyDown(KeyCode.Space))
            MoveToKey();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            MoveToMouse();
    }

    private void KeepOnPlatform()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(ScanAngle), out hit, Mathf.Infinity, GroundLayer))
        {
            _controller.MoveOrder(0, 0, 0, 1);
        }
        else
        {
            _controller.MoveOrder(1, 0, 0, 0);
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(ScanAngle), Color.red);
    }

    private void MoveToKey()
    {
        Agent.SetDestination(Key.transform.position);
    }

    private void MoveToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1000))
        {
            Agent.SetDestination(hitData.point);
        }
        
        Debug.Log("MoveToMouse!");
    }
}
