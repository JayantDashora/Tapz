using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveCore4Script : CoreAbstractClass
{
    // Variables

    [SerializeField] private GameObject explosive;

    // Special Attack

    protected override void SpecialAttack(){
        // Add game juice here 
        Instantiate(explosive, transform.position, transform.rotation);
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
