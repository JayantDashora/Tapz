using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneManEnemyScript : BasicEnemy
{
    // Variables


    // Checking collisions

    override protected void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Core")){
            coreHealthScriptRef.coreHealth -= enemyDamage; // Damaging the core
            SpecialAttack();
            Destruct();
        }
    }

    // Bomb rain when one man collides with the core 

    private void SpecialAttack(){

        // Special Attack
        Debug.Log("Om");

        // The special attack will have a very big explosion on the center of the screen with a lot of screen shake and other effects

    }

}
