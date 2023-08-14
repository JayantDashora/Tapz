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
}
