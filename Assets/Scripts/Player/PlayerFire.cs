using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{   
    public Weapon weapon = null;

    private void Update() {
        if(Input.GetMouseButton(0)){
            if(weapon != null){
                weapon.Fire();
            }
        }
    }
}
