using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveCore1Script : CoreAbstractClass
{

    // Variables

    [SerializeField] private GameObject saw;
    
    // Special Attack

    protected override void SpecialAttack(){
        // Add game juice here 
        Instantiate(saw, transform.position, transform.rotation);
        
    }

}
