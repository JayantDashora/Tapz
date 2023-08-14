using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManagerScript : MonoBehaviour
{
    // Variables 

    private int enemyAccess = 3;
    private Camera mainCamera;

    [SerializeField] private int budget = 50;
    [SerializeField] private int budgetGainPerWave;
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private List<int> enemiesCost = new List<int>();
    

    // References

    private GameStatsManagerScript statsRef;

    void Start(){
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        mainCamera = Camera.main;
    }

    void Update(){
        
        // Check whether enemies are left or not

        if((GameObject.FindGameObjectsWithTag("Enemy").Length == 0)){
            SpawnNewWave();
        }

        // Changing difficulty with waves 

        switch(statsRef.waveNumber){

            case 1:
                enemyAccess = 3;
                break;

            case 8:
                enemyAccess = 7;
                break;

            case 20:
                enemyAccess = 10;
                break;

            case 35:
                enemyAccess = 14;
                break;
        }
        
    }

    // Spawn a new wave
    private void SpawnNewWave(){

        int tempBudget = budget;

        while(tempBudget > 0){
            for(int i = 0; i < enemyAccess ; i++){
                if(tempBudget - enemiesCost[i] >= 0){

                    int choice = Random.Range(0,2);

                    if(choice == 1){

                        // Spawning the enemy on a random location

                        Instantiate(enemies[i], GenerateSpawnPoint(), transform.rotation);
                        tempBudget -= enemiesCost[i];
                    }

                }
            }
        }



        // Increase the budget for the next wave
        budget += budgetGainPerWave;

        statsRef.waveNumber++;
    }


    // Generate a random spawn point for the enemy
    private Vector3 GenerateSpawnPoint(){
    
        int side = Random.Range(0,4);

        // IF SIDE = 0 => SPAWN ON LEFT SIDE OF THE SCREEN
        // IF SIDE = 1 => SPAWN ON TOP SIDE OF THE SCREEN
        // IF SIDE = 2 => SPAWN ON RIGHT SIDE OF THE SCREEN
        // IF SIDE = 3 => SPAWN ON BOTTOM SIDE OF THE SCREEN

        Vector3 spawnPoint = Vector3.zero;

        switch(side){

            case 0:
                // LEFT
                spawnPoint.x = 0;
                spawnPoint.y = Random.value; 
                spawnPoint.x -= 0.1f;            
                break;

            case 1:
                // TOP
                spawnPoint.y = 1;
                spawnPoint.x = Random.value; 
                spawnPoint.y += 0.1f;  
                break;
                                
            case 2:
                // RIGHT
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;  
                spawnPoint.x += 0.1f;
                
                break;

            case 3:
                // BOTTOM
                spawnPoint.y = 0;
                spawnPoint.x = Random.value; 
                spawnPoint.y -= 0.1f;
                break;
                                
        }


        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        return worldSpawnPoint;
    }

}
