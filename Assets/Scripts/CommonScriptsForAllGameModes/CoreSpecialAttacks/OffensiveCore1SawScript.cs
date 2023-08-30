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

    private Animator animator;
    [SerializeField] private ParticleSystem particleEffect;

    [SerializeField] private ParticleSystem killEffect;


    // Functions

    private void Start() {
        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<OffensiveCore1Script>();
        animator = GetComponent<Animator>();

        Instantiate(particleEffect,transform.position,Quaternion.identity);
        CameraShakeEffect.Instance.ScreenShake(6f,0.3f);
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
            CameraShakeEffect.Instance.ScreenShake(3f,0.2f);
            sawHealth -= enemyDamage; // This saw takes same damage from all different types of enemies

            // Add game juice here when the enemy gets destroyed
            Instantiate(killEffect,other.transform.position,Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

    // Check whether health is remaining or not and if not removing the saw

    private void CheckHealth(){
        if(sawHealth <= 0){
            // Add game juice here
            animator.SetTrigger("fade");
            coreScriptRef.isUsingSpecialAttack = false;
            Invoke("Remove", 1.5f);
            
        }
    }


    // Destroy object 

    private void Remove(){
        Destroy(gameObject);
    }
}
