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
    private float fireRateCounter = 0;
    public float reloadTime = 0.4f;
    private float reloadTimer = 0;

    [Space]
    public LayerMask mask;   
    public ParticleSystem muzzleFlash = null;
    public AmmoCounter counter = null;
    public Animator animator = null;
    public AudioSource audio = null;
    public ScreenShake screenShake = null;

    public bool infiniteAmmo = false;
    private bool isFiring = false;

    private void Start() {
        ammoCount = maxAmmo;
        cam = Camera.main;
        counter.UpdateText(ammoCount);
    }

    private void Update() {
        if(fireRateCounter > 0 || reloadTimer > 0){
            fireRateCounter -= Time.deltaTime;
            reloadTimer -= Time.deltaTime;
        } else if(isFiring && ammoCount > 0){
            Fire();
        }
    }

    void Fire(){
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, effectiveDistance, mask)){
            var selection = hit.transform;
            selection.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        fireRateCounter = fireRate;
        muzzleFlash.Play();
        audio.Play();
        animator.Play("Firing");

        StartCoroutine(screenShake.Shake(0.1f, 0.05f));
        if(!infiniteAmmo){
            ammoCount--;
            counter.UpdateText(ammoCount);
        }   
    }

    public void BeginFiring(){
        isFiring = true;
    }

    public void StopFiring(){
        isFiring = false;

        if(ammoCount == 0){
            Reload();
        }
    }

    public void Reload(){
        animator.Play("Reload");
        reloadTimer = reloadTime;
        ammoCount = maxAmmo;
        counter.UpdateText(ammoCount);
    }
}
