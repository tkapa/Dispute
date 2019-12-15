using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform body;

    float xRotation = 0f;
    float mouseX = 0f;
    float mouseY = 0f;

    public SOFloat mouseSensitivity = null;
    public SOBool invertY = null;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.value * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.value * Time.deltaTime;

        if(invertY.value){
            xRotation += mouseY;
        } else {
            xRotation -= mouseY;
        }

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}
