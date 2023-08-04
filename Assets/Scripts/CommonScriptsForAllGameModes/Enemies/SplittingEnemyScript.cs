using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SplittingEnemyScript : BasicEnemy
{

    // Variables
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject[] possibleEnemies;

    // Functions 

    override protected void Update(){

        // For perpetual rotation
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        UserInput();
        MoveTowardsCore();
        CheckHealth();
        CheckOffbounds();

    }


    // Constantly moves the enemy towards the core
    override protected void MoveTowardsCore(){

        transform.position = Vector2.MoveTowards(transform.position, screenCenter, enemySpeed * Time.deltaTime);

    }

    // Spawn new enemies
    private void SpawnNewEnemies(){
        for(int i = 0 ; i < (Random.Range(2,5)); i++){
            Vector3 offset = new Vector3(Random.Range(-0.7f,0.7f),Random.Range(-0.7f,0.7f), 0f);
            Instantiate(possibleEnemies[Random.Range(0,3)], transform.position + offset, transform.rotation);
        }
    }

    // The code to run when the enemy is tapped 
    override protected void Tapped(){
        // Add game juice here
        enemyHealth -= 10;          
    } 

    // Check whether to destroy or not 

    override protected void CheckHealth(){
        if(enemyHealth <= 0){

            SpawnNewEnemies();
            statsRef.gameCurrency += currencyGainOnTap;
            Destruct();
                        
        }
    }



}
