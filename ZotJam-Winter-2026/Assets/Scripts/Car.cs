using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Car : MonoBehaviour
{
    public Camera playerCamera;
    public float moveSpeed = 1f;
    public float rotateSpeed = 0.5f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        // Left movement
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            moveDirection.x = -right.x * moveSpeed;
            // Rotates the car towards the left
            if (transform.rotation.y > -0.3){
                transform.rotation *= Quaternion.Euler(0,  -rotateSpeed, 0);
            }
        }
        // Right movement
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            moveDirection.x = right.x * moveSpeed;
            // Rotates the car towards the right
            if (transform.rotation.y < 0.3){
                transform.rotation *= Quaternion.Euler(0,  rotateSpeed, 0);
            }
        }
    

        if (canMove){
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}