using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveCore1Script : CoreAbstractClass
{

    // Variables

    [SerializeField] private GameObject shield;
    
    // Special Attack

    protected override void SpecialAttack(){
        // Add game juice here
        Instantiate(shield, transform.position, transform.rotation);
        
    }

}
