using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Camera cam = null;

    public LayerMask mask;

    public float damage = 50f;
    public float effectiveDistance = 100f;
    
    private void Start() {
        cam = Camera.main;
    }

    public void Fire(){
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, effectiveDistance, mask)){
            var selection = hit.transform;
            selection.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
