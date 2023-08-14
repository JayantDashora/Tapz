using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemiesBaseScript : BasicEnemy
{

    // Variables

    [SerializeField] private float shootFrequency;
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform shootPoint;


    // Functions

    override protected void Start(){

        selfCollider = GetComponent<Collider2D>();
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
        powerupStatus = GameObject.Find("GameManagers/PowerupStatusManager").GetComponent<PowerupStatusManagerScript>();
        
        // Invoke the shooting nature of the enemy
        InvokeRepeating("ShootAtCore", 0.1f, shootFrequency);
    }

    private void ShootAtCore(){
        Instantiate(bullet, shootPoint.position, transform.rotation);
    }


}
