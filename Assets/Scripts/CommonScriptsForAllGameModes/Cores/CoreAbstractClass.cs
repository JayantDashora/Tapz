using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreAbstractClass : MonoBehaviour
{
    // Variables 

    [SerializeField] protected int coreHealth; 

    // Functions 

    // Checking collisions
    private void OnCollisionEnter2D(Collision2D other)
    {

        //Checking whether the core has collided with the enemy

        if(other.gameObject.CompareTag("NormalEnemy")){
            DealDamage();
        }



    }

    // Dealing damage on the core
    protected void DealDamage(){
        coreHealth--;
        Debug.Log(coreHealth);

        // Can add all the game juice here 

    }

    // Special attack abstract function

    protected abstract void SpecialAttack();
    
}
