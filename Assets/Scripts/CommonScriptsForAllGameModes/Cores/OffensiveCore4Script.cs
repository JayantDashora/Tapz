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
}
