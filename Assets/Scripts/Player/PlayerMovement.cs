using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheck = null;
    private float groundDistance = 0.4f;

    [SerializeField]
    private LayerMask groundMask = 0;

    CharacterController controller = null;

    bool isGrounded = false;

    private float moveX, moveZ;

    private void Start() {
        if(TryGetComponent<CharacterController>(out CharacterController contr)){
            controller = contr;
        }
    }

    private void Update() {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void FixedUpdate() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);        
    }
}
