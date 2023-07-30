using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreAbstractClass : MonoBehaviour
{
    // Variables 

    [SerializeField] protected float coreHealth; 
    [SerializeField] private EnemyData enemyDataStore;

    // Functions 

    // Checking collisions
    private void OnCollisionEnter2D(Collision2D other)
    {

        //Checking whether the core has collided with the enemy and dealing damage accordingly

        switch (other.gameObject.tag)
        {
            case "NormalEnemy":
                coreHealth -= enemyDataStore.normalEnemyDamage;
                break;

            case "FastEnemy":
                coreHealth -= enemyDataStore.fastEnemyDamage;
                break;

            case "SlowEnemy":
                coreHealth -= enemyDataStore.slowEnemyDamage;
                break;

            case "ExploderEnemy":
                coreHealth -= enemyDataStore.exploderEnemyDamage;
                // Add functionality to damage the walls/attacking units here 

                break;

        }

        DamageEffect();

    }

    // Common function for dealing the damage to the core, can be used for game juice
    protected void DamageEffect(){
        Debug.Log(coreHealth);

        // Can add all the game juice here 

    }

    // Special attack abstract function

    protected abstract void SpecialAttack();
    
}
