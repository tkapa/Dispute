using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{   
    public Weapon weapon = null;

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            if(weapon != null){
                weapon.BeginFiring();
            }
        } else if(Input.GetMouseButtonUp(0)){
            if(weapon != null){
                weapon.StopFiring();
            }
        }
    }
}
