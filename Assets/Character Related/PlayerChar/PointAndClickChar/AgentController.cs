using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(PlayerController))]
public class AgentController : MonoBehaviour
{
    private PlayerController _controller;
    public LayerMask GroundLayer;
    private RaycastHit _hitData;

    public NavMeshAgent Agent;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<PlayerController>();
        Agent = GetComponent<NavMeshAgent>();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
            MoveToMouse();

        if (!Agent.hasPath)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out _hitData);
            transform.DOLookAt(_hitData.point, 0.8f, AxisConstraint.Y);
        }
    }

    private void MoveToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hitData))
        {
            Agent.SetDestination(_hitData.point);
        }

        Debug.Log("MoveToMouse!");
    }
}
