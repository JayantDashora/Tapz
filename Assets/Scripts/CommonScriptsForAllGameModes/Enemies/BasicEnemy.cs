using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    // Variables 

    [SerializeField] protected int enemyHealth;
    [SerializeField] protected float enemySpeed;
    [SerializeField] protected ParticleSystem destructEffect;

    Vector3 screenCenter = new Vector3(0,0,-10);

    // Update is called once per frame
    protected virtual void Update()
    {
        MoveTowardsCore();
    }

    // Constantly moves the enemy towards the core
    protected void MoveTowardsCore(){

        transform.LookAt(screenCenter, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, screenCenter, enemySpeed * Time.deltaTime);

    }

    // Checking collisions

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Core")){
            Destruct();
        }
    }

    // Destroying the enemy gameobject

    protected virtual void Destruct(){
        // Add game juice here
        Instantiate(destructEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
;