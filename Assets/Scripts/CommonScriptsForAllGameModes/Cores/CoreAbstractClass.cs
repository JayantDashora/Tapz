using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreAbstractClass : MonoBehaviour
{
    // Variables 

    [SerializeField] protected int coreHealth; 

    // Functions 

    protected virtual void TakeDamage(){
        coreHealth--;
    }

    protected abstract void SpecialAttack();

}
