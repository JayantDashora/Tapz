using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutEnemyScript : BasicEnemy
{

    // Variables
    [SerializeField] private float rotationSpeed;
    private GameObject fadeSprite;

    // Functions

    override protected void Start(){
        selfCollider = GetComponent<Collider2D>();
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        fadeSprite = GameObject.Find("FadeSprite");
        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
    }
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

    // Checking collisions

    override protected void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Core")){
            coreHealthScriptRef.coreHealth -= enemyDamage; // Damaging the core
            Blackout();
            Destruct();
        }
    }

    // Blackout the screen
    private void Blackout(){

        fadeSprite.transform.position = new Vector3(0,0,0);

    }
}
