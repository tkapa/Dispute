using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float sprintTime = 6.0f;
    public float sprintTimer = 0.0f;

    public float sprintCooldownTime = 3.0f;
    public float sprintCooldownTimer = 0.0f;

    public ValueBar sprintSlider = null;

    bool canSprint = true;

    PlayerMovement movement = null;

    // Start is called before the first frame update
    void Start()
    {
        sprintTimer = sprintTime;
        sprintSlider.SetValue(sprintTimer/sprintTime);

        if(TryGetComponent<PlayerMovement>(out PlayerMovement move)){
            movement = move;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && canSprint){
            movement.isSprinting = !movement.isSprinting;
        }

        if(movement.isSprinting && sprintTimer > 0){
            sprintTimer -= Time.deltaTime;
            sprintSlider.SetValue(sprintTimer/sprintTime);
        } else if(sprintTimer <= 0 && canSprint){
            movement.isSprinting = false;
            canSprint = false;
            StartCoroutine(SprintCooldown(sprintCooldownTime));
        } else if(!movement.isSprinting && sprintTimer < sprintTime && canSprint){
            sprintTimer += Time.deltaTime;
            sprintSlider.SetValue(sprintTimer/sprintTime);
        }
    }

    IEnumerator SprintCooldown(float coolingTime){
        float counter = coolingTime;

        while(counter > 0){
            counter -= Time.deltaTime;
            yield return null;
        }

        canSprint = true;
        sprintTimer = sprintTime;
        sprintSlider.SetValue(sprintTimer/sprintTime);
    }
}
