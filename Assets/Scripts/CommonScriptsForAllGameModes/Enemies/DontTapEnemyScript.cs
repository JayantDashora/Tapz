using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTapEnemyScript : BasicEnemy
{
    // Variables

    [SerializeField] private float enemyDamageOnTapped;
    override protected void Tapped(){
        // Add game juice here
        coreHealthScriptRef.coreHealth -= enemyDamageOnTapped; // Damaging the core
        enemyHealth -= 10;            
    } 

}