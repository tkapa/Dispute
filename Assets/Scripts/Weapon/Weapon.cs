using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Camera cam = null;

    [Header("Weapon Properties")]
    public int maxAmmo = 30;
    public int ammoCount = 0;
    public float damage = 50f;
    public float effectiveDistance = 100f;
    public float fireRate = 0.2f;

    [Space]
    public LayerMask mask;   
    public ParticleSystem muzzleFlash = null;

    public bool infiniteAmmo = false;
    private bool isFiring = false;

    private void Start() {
        ammoCount = maxAmmo;
        cam = Camera.main;
    }

    public void BeginFiring(){
        isFiring = true;
        StartCoroutine(Fire());
    }

    public void StopFiring(){
        isFiring = false;
        StopCoroutine(Fire());

        if(ammoCount == 0){
            Reload();
        }
    }

    public void Reload(){
        //TODO: Play Reload animation
        ammoCount = maxAmmo;
        Debug.Log("Ammo count reset");
    }

    IEnumerator Fire(){
        while(isFiring && ammoCount > 0){
            Debug.Log("Bang");

            //TODO: Play Firing Animation and Juice here Reloading
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, effectiveDistance, mask)){
                var selection = hit.transform;
                selection.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            muzzleFlash.Play();
            
            if(!infiniteAmmo)
                ammoCount--;

            yield return new WaitForSeconds(fireRate);
        }
    }
}
