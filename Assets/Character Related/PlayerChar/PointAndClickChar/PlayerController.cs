using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int currentMouseSensitivity;
    private int currentMovementSpeed;

    [SerializeField] private int mouseSensitivity;
    [SerializeField] private int movementSpeed;

    float xRotation = 0f;

    public Transform camTransform;
    public CharacterController playerController;

    void Start()
    {
        currentMouseSensitivity = mouseSensitivity;
        currentMovementSpeed = movementSpeed;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * currentMouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * currentMouseSensitivity * Time.deltaTime;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        //MoveOrder(mouseX, mouseY, moveX, moveZ);
    }

    public void MoveOrder(float rotateX, float rotateY, float moveX, float moveZ)
    {
        xRotation -= rotateY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * rotateX);

        Vector3 charMovement = transform.right * moveX + transform.forward * moveZ;
        playerController.Move(charMovement * currentMovementSpeed * Time.deltaTime);
    }
}
