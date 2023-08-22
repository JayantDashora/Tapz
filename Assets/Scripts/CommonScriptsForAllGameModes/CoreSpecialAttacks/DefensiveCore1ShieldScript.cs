using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveCore1ShieldScript : MonoBehaviour
{
    // Variables

    [SerializeField] private float shieldHealth;
    [SerializeField] private float enemyDamage;
    private DefensiveCore1Script coreScriptRef;


    // Functions

    private void Start() {
        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<DefensiveCore1Script>();
    }

    private void Update() {
        CheckHealth();
    }

    // Checking collisions

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){

            // Add game juice here when the enemy damages the shield
            shieldHealth -= enemyDamage; // This shield takes same damage from all different types of enemies

            // Add game juice here when the enemy gets destroyed
            //Destroy(other.gameObject);
        }
    }

    // Check whether health is remaining or not and if not removing the shield

    private void CheckHealth(){
        if(shieldHealth <= 0){
            // Add game juice here
            coreScriptRef.isUsingSpecialAttack = false;
            Destroy(gameObject);
            
        }
    }
}
