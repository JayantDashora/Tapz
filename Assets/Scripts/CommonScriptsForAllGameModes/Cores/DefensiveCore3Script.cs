using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveCore3Script : CoreAbstractClass
{
    // Variables

    [SerializeField] private GameObject healingDrone;
    private Vector3 spawnPoint = new Vector3(-4f,0,0);
    
    // Special Attack

    protected override void SpecialAttack(){
        // Add game juice here 
        Instantiate(healingDrone,spawnPoint, transform.rotation);
    }

    // Special attack indicator

    protected override void SpecialAttackIndicator(){

        // Indicator that you can use the special attack
        // Also add game juice here

        if((statsRef.gameCurrency > specialAttackCost)&& (isUsingSpecialAttack == false)){
            animator.SetBool("isCharged", true);
        }
        else{
            animator.SetBool("isCharged", false);
        }
        

    }

}
