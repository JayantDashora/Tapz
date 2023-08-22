using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveCore5Script : CoreAbstractClass
{
    // Variables

    [SerializeField] private GameObject hideCore;
    private Vector3 spawnPoint = new Vector3(0,4f,0);
    
    // Special Attack
    protected override void SpecialAttack(){
        // Add game juice here
        Instantiate(hideCore,spawnPoint, transform.rotation);
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
