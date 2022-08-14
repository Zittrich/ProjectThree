using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(PlayerController))]
public class AgentController : MonoBehaviour
{
    private PlayerController _controller;
    public LayerMask GroundLayer;

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

        if (Input.GetKeyDown(KeyCode.Mouse0))
            MoveToMouse();

        if (!Agent.hasPath)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            transform.LookAt(ray.direction);
        }
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
