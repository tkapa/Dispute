﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSprint : MonoBehaviour
{
    public float sprintTime = 6.0f;
    private float sprintTimer = 0.0f;

    public float sprintCooldownTime = 3.0f;
    private float sprintCooldownTimer = 0.0f;

    public Slider sprintSlider = null;

    bool canSprint = true;

    PlayerMovement movement = null;

    // Start is called before the first frame update
    void Start()
    {
        sprintTimer = sprintTime;

        if(TryGetComponent<PlayerMovement>(out PlayerMovement move)){
            movement = move;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            movement.isSprinting = !movement.isSprinting;
        }
    }
}