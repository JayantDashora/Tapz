using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveCore2Script : CoreAbstractClass
{
    // Variables

    [SerializeField] private GameObject forceField;
    
    // Special Attack

    protected override void SpecialAttack(){
        // Add game juice here 
        Instantiate(forceField, transform.position, transform.rotation);
        
    }

}
