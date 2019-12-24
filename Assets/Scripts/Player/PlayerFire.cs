using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{   
    public Weapon weapon = null;
    public SOBool isPaused = null;

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !isPaused.value){
            if(weapon != null){
                weapon.BeginFiring();
            }
        } else if(Input.GetMouseButtonUp(0) && !isPaused.value){
            if(weapon != null){
                weapon.StopFiring();
            }
        }

        if(Input.GetKeyDown(KeyCode.R) && !isPaused.value){
            weapon.Reload();
        }
    }
}
