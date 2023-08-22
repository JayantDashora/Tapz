using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreTurretScript : MonoBehaviour
{
    [SerializeField] private float shootFrequency;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float senseRadius;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float lifetime;

    private float timeSinceLastShot;
    private Collider2D[] targets;
    private Animator animator;

    private OffensiveCore3Script coreScriptRef;

    private void Start()
    {
        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<OffensiveCore3Script>();
        Invoke("SelfDestruct", lifetime);
        timeSinceLastShot = 0f;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Increment time since last shot
        timeSinceLastShot += Time.deltaTime;

        // Check if enough time has passed to shoot
        if (timeSinceLastShot >= shootFrequency)
        {
            // Find all targets within the sensing radius
            targets = Physics2D.OverlapCircleAll(transform.position, senseRadius);

            // Shoot at the first valid target
            foreach (Collider2D targetCollider in targets)
            {
                if (targetCollider.gameObject.CompareTag("Enemy"))
                {
                    // Calculate rotation to look at the target without changing x and y rotations
                    Vector3 directionToTarget = targetCollider.transform.position - transform.position;
                    transform.up = directionToTarget;

                    // Instantiate the bullet at the shootPoint
                    // Add game juice here
                    Instantiate(bullet, shootPoint.position, transform.rotation);
                    
                    animator.SetBool("isShooting", true);

                    // Reset time since last shot
                    timeSinceLastShot = 0f;

                    // Break after shooting at the first valid target
                    break;
                }

                animator.SetBool("isShooting", false);
            }
        }
    }

    // Destroy gameobject 

    private void SelfDestruct(){
        // Add game juice here
        coreScriptRef.isUsingSpecialAttack = false;
        Destroy(gameObject);
    }

}
