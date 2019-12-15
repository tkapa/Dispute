using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maximumHealth = 100f;
    private float currentHealth;

    private void Start() {
        currentHealth = maximumHealth;
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;

        if(currentHealth <= 0){
            Death();
        }
    }

    void Death(){
        Debug.Log("Poof");
        Destroy(this.gameObject);
    }
}
