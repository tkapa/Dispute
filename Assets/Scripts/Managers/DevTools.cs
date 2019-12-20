using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public PauseManager pauseManager = null;

    public Weapon weapon = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            pauseManager.LevelComplete();
        }

        if(Input.GetKeyDown(KeyCode.I)){
            weapon.infiniteAmmo = !weapon.infiniteAmmo;
        }
    }
}
