using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveCore1SawScript : MonoBehaviour
{
    // Variables

    [SerializeField] private float sawHealth;
    [SerializeField] private float enemyDamage;
    [SerializeField] private float rotationSpeed;

    private OffensiveCore1Script coreScriptRef;


    // Functions

    private void Start() {
        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<OffensiveCore1Script>();
    }

    private void Update() {

        // For perpetual rotation
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        
        CheckHealth();
    }

    // Checking collisions

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){

            // Add game juice here when the enemy damages the saw
            sawHealth -= enemyDamage; // This saw takes same damage from all different types of enemies

            // Add game juice here when the enemy gets destroyed
            Destroy(other.gameObject);
        }
    }

    // Check whether health is remaining or not and if not removing the saw

    private void CheckHealth(){
        if(sawHealth <= 0){
            // Add game juice here
            coreScriptRef.isUsingSpecialAttack = false;
            Destroy(gameObject);
            
        }
    }
}
