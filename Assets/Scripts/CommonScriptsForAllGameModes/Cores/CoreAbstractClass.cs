using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreAbstractClass : MonoBehaviour
{
    // Variables 
    private CoreHealth coreHealthRef; 

    // Functions 

    private void Start() {
        coreHealthRef = GetComponent<CoreHealth>();
    }

    // Checking collisions
    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageEffect();

    }

    // Common function for dealing the damage to the core, can be used for game juice
    protected void DamageEffect(){
        // Can add all the game juice here 

    }

    // Special attack abstract function

    protected abstract void SpecialAttack();
    
}
