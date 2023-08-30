using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float senseRadius;
    [SerializeField] private float rotationalSpeed;
    [SerializeField] private float orbitRadius;
    [SerializeField] private float lifetime;

    [SerializeField] private ParticleSystem killEffect;

    private bool canKill = false;
    private Collider2D target;

    private Vector3 screenCenter = new Vector3(0,0,0);

    private OffensiveCore2Script coreScriptRef;

    private void Start() {
        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<OffensiveCore2Script>();
        Invoke("SelfDestruct", lifetime);
    }
    
    private void Update() {
        if (!canKill) {
            // Return to the core to defend it
            if (Vector3.Distance(transform.position, screenCenter) >= orbitRadius) {
                transform.position = Vector2.MoveTowards(transform.position, screenCenter, speed * Time.deltaTime);
            } else {
                transform.RotateAround(screenCenter, Vector3.forward, rotationalSpeed * Time.deltaTime);
            }

            // Search for enemies in range
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, senseRadius);

            foreach (Collider2D enemyCollider in enemiesInRange) {
                if (enemyCollider.gameObject.CompareTag("Enemy")) {
                    canKill = true;
                    target = enemyCollider;
                    break; // Exit the loop once an enemy is found
                }
            }
        } else {
            if (target != null) {
                Vector3 targetPos = target.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            } else {
                canKill = false; // Reset when there's no target
            }
        }
    }


    // Checking collisions and killing enemies

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            // Add game juice here
            canKill = false;
            Instantiate(killEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

    // Destroy gameobject 

    private void SelfDestruct(){
        // Add game juice here
        Instantiate(killEffect, screenCenter, Quaternion.identity);

        Instantiate(killEffect, new Vector3(2,2,0), Quaternion.identity);
        Instantiate(killEffect, new Vector3(2,-2,0), Quaternion.identity);
        Instantiate(killEffect, new Vector3(-2,2,0), Quaternion.identity);
        Instantiate(killEffect, new Vector3(-2,-2,0), Quaternion.identity);

        coreScriptRef.isUsingSpecialAttack = false;
        Destroy(gameObject);
    }

}
