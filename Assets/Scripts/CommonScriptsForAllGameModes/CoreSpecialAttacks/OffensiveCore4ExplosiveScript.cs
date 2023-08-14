using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveCore4ExplosiveScript : MonoBehaviour
{

    // Variables

    [SerializeField] private float lifetime;

    private GameObject[] allEnemies;

    private OffensiveCore4Script coreScriptRef;

    void Start(){

        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<OffensiveCore4Script>();
        GameJuice();
        Explode();
        Invoke("SelfDestruct", lifetime);
        
    }

    // Kill all enemies on the screen

    private void Explode(){

        // Find all the enemies
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Destroy all the enemies
        foreach(GameObject enemy in allEnemies){
            Destroy(enemy);
        }
    }

    // Game juice (Explosion particle effects/ Screen shakes/ other effects to make it look better)

    private void GameJuice(){
        // Add game juice here
    }

    // Destroy gameobject 

    private void SelfDestruct(){
        // Add game juice here
        coreScriptRef.isUsingSpecialAttack = false;
        Destroy(gameObject);
    }
}
