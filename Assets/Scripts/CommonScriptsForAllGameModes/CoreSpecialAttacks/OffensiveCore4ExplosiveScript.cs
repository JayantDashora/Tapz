using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveCore4ExplosiveScript : MonoBehaviour
{

    // Variables

    [SerializeField] private float lifetime;

    private GameObject[] allEnemies;

    [SerializeField] private ParticleSystem explosionEffect1;
    [SerializeField] private GameObject explosionEffect2;

    [SerializeField] private Vector3[] spawnPoints;

    private OffensiveCore4Script coreScriptRef;
    
    private Animator flashAnimator;


    void Start(){

        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<OffensiveCore4Script>();
        flashAnimator = GameObject.Find("UI/Canvas/FlashEffect").GetComponent<Animator>();
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

        flashAnimator.SetTrigger("flashWhite");

        foreach(Vector3 spawnPoint in spawnPoints){
            Instantiate(explosionEffect1, spawnPoint, Quaternion.identity);
            Instantiate(explosionEffect2, spawnPoint, Quaternion.identity);
        }

        CameraShakeEffect.Instance.ScreenShake(30f,3f);
            
    }

    // Destroy gameobject 

    private void SelfDestruct(){
        // Add game juice here
        coreScriptRef.isUsingSpecialAttack = false;
        Destroy(gameObject);
    }
}
