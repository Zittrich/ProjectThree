using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private PlayerController _controller;
    public LayerMask GroundLayer;
    private RaycastHit _hitData;
    public Animator Animator;
    public GameObject ClickPointer;
    public float ClickPointerDuration;

    public NavMeshAgent Agent;
    public float Speed;
    public float StairClimbingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<PlayerController>();
        Agent = GetComponent<NavMeshAgent>();
        Cursor.visible = true;
        Agent.speed = Speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && !Agent.isOnOffMeshLink)
        {
            MoveToMouse();
        }

        if (!Agent.hasPath)
        {
            Animator.SetBool("Is Run", false);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out _hitData);
            transform.DOLookAt(_hitData.point, 0.8f, AxisConstraint.Y);
        }

        if (Agent.hasPath)
        {
            Animator.SetBool("Is Run", true);
        }

        Agent.speed = Agent.isOnOffMeshLink ? StairClimbingSpeed : Speed;
    }

    private void MoveToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hitData))
        {
            Agent.SetDestination(_hitData.point);
            GameObject thisIndicator = Instantiate(ClickPointer, _hitData.point + new Vector3(0, 0.5f, 0), Quaternion.Euler(-90, 0, 0));
            Destroy(thisIndicator, ClickPointerDuration);
        }

        Debug.Log("MoveToMouse!");
    }
}
