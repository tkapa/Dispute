using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    public float speed = 6f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheck = null;
    private float groundDistance = 0.4f;

    [SerializeField]
    private LayerMask groundMask = 0;

    CharacterController controller = null;
    Rigidbody rb = null;
    Vector3 velocity;

    bool isGrounded = false;

    private float moveX, moveZ;

    private void Start() {
        if(TryGetComponent<CharacterController>(out CharacterController contr)){
            controller = contr;
        }
        if(TryGetComponent<Rigidbody>(out Rigidbody rigidbody)){
            rb = rigidbody;
        }
    }

    private void Update() {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate() {

        if(isGrounded && velocity.y < 0f){
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);        
    }
}
