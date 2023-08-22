using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicEnemy : MonoBehaviour
{

    // Variables 

    [SerializeField] protected int enemyHealth;
    [SerializeField] protected float enemySpeed;
    [SerializeField] protected int currencyGainOnTap;

    [SerializeField] protected float enemyDamage;
    [SerializeField] protected ParticleSystem destructEffect;

    protected Vector3 screenCenter = new Vector3(0,0,-10);
    protected Collider2D selfCollider;

    protected CoreHealth coreHealthScriptRef;
    protected PowerupStatusManagerScript powerupStatus;
    protected GameStatsManagerScript statsRef;

    // Functions
    protected virtual void Start(){

        selfCollider = GetComponent<Collider2D>();
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        powerupStatus = GameObject.Find("GameManagers/PowerupStatusManager").GetComponent<PowerupStatusManagerScript>();
        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();

    }
    protected virtual void Update()
    {
        UserInput();
        MoveTowardsCore();
        CheckHealth();
        CheckOffbounds();
    }

    // Constantly moves the enemy towards the core
    protected virtual void MoveTowardsCore(){

        transform.LookAt(screenCenter, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, screenCenter, enemySpeed * Time.deltaTime);

    }

    // Checking collisions

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Core")){

            coreHealthScriptRef.coreHealth -= enemyDamage; // Damaging the core
            Destruct();
        }
    }

    // Destroying the enemy gameobject

    protected virtual void Destruct(){
        // Add game juice here
        Instantiate(destructEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // User input
    protected virtual void UserInput(){

        // Checks whether the player is touching the screen or not 

        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began){

                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

                // Add game juice here to make the tap feel more responsive

                if(selfCollider == touchedCollider){
                    Tapped(touchPosition);

                    CameraShakeEffect.Instance.ScreenShake(2f,0.1f);
                }
            }
        }


    } 

    // The code to run when the enemy is tapped 

    protected virtual void Tapped(Vector2 touchPos){
        
        switch(powerupStatus.powerupChoice){
            
            // Taking the powerup status from the script and dealing damage accordingly 

            // No powerup
            case 0:
                // Add game juice here for normal kill
                enemyHealth -= 10;
                break;
                
            // Laser click powerup
            case 1:
            // Add game juice here for laser powerup
                enemyHealth -= 50;
                break;

            // Explosive Click
            case 2:
                // Add game juice here for explosive powerup (Some explosion particle effect or screen shake)
                Collider2D[] touchedColliders = Physics2D.OverlapCircleAll(touchPos, 1.5f);

                foreach(Collider2D collider in touchedColliders){
                    // Add game juice here
                    if(collider.gameObject.CompareTag("Enemy")){
                        Destroy(collider.gameObject);
                    }
                    
                }
                break;

            


        }
                  
    } 

    // Check whether to destroy or not 

    protected virtual void CheckHealth(){
        if(enemyHealth <= 0){
            statsRef.gameCurrency += currencyGainOnTap;
            Destruct();
                        
        }
    }

    // Check whether enemy is offbounds

    protected virtual void CheckOffbounds(){
        if((transform.position.y < -10) || (transform.position.y > 10) || (transform.position.x < -10)|| (transform.position.x > 10)){
            Destroy(gameObject);
        }
    }

}