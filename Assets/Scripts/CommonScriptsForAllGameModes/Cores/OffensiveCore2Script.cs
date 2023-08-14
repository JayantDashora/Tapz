using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveCore2Script : CoreAbstractClass
{
    // Variables

    [SerializeField] private GameObject wreckingBall;
    private Vector3 spawnPoint = new Vector3(3f,0,0);

    // Special Attack

    protected override void SpecialAttack(){
        // Add game juice here 
        Instantiate(wreckingBall, spawnPoint, transform.rotation);
        
    }
}
