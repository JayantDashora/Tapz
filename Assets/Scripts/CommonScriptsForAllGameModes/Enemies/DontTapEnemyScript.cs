using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTapEnemyScript : BasicEnemy
{
    // Variables

    [SerializeField] private float enemyDamageOnTapped;

    [SerializeField] private GameObject healEffect;
    [SerializeField] private ParticleSystem healParticle;

    override protected void Tapped(Vector2 touchPos){
        // Add game juice here
        coreHealthScriptRef.coreHealth -= enemyDamageOnTapped; // Damaging the core
        uiManager.PopCoreHealthUI();
        enemyHealth -= 10;            
    } 

    override protected void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Core")){

            Instantiate(healEffect,new Vector3(0,0,0),Quaternion.identity);
            Instantiate(healParticle,new Vector3(0,0,0),Quaternion.identity);


            coreHealthScriptRef.coreHealth -= enemyDamage; // Damaging the core
            uiManager.PopCoreHealthUI();
            Destruct();
        }
    }

}
