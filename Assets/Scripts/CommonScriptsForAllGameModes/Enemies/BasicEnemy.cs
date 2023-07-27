using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    // Variables 

    [SerializeField] protected int enemyHealth;
    [SerializeField] protected int enemyDamage;
    [SerializeField] protected float enemySpeed;

    Vector3 screenCenter = new Vector3(0,0,-10);

    // Update is called once per frame
    void Update()
    {
        MoveTowardsCore();
    }

    // Constantly moves the enemy towards the core
    protected void MoveTowardsCore(){

        transform.LookAt(screenCenter, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, screenCenter, enemySpeed * Time.deltaTime);

    }
}
;