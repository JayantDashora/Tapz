using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreAbstractClass : MonoBehaviour
{
    // Variables 

    private CoreHealth coreHealthRef; 
    private Collider2D selfCollider;

    protected GameStatsManagerScript statsRef;
    private PowerupStatusManagerScript powerupStatus;

    [HideInInspector] public bool isUsingSpecialAttack;

    [SerializeField] protected int specialAttackCost;

    float lastTapTime = 0f;
    float doubleTapThreshold = 0.3f;    

    [SerializeField] private GameObject normalTapEffect;
    [SerializeField] private GameObject laserTapEffect;
    [SerializeField] private ParticleSystem laserParticleSystem;

    [SerializeField] private GameObject explosionTapEffect;
    [SerializeField] private ParticleSystem explosionParticleSystem;

    [SerializeField] private GameObject healTapEffect;
    [SerializeField] private ParticleSystem healParticleSystem;

    [HideInInspector] public Animator animator;


    // Functions 

    private void Start() {
        coreHealthRef = GetComponent<CoreHealth>();
        selfCollider = GetComponent<Collider2D>();
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        powerupStatus = GameObject.Find("GameManagers/PowerupStatusManager").GetComponent<PowerupStatusManagerScript>();
        animator = GetComponent<Animator>();

    }

    // Update function 

    protected virtual void Update(){

        UserInput();
        SpecialAttackIndicator();

    }

    // Checking collisions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy")){

            // The effect of the enemy collision
            // Add game juice here




        }

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
                // Different tap effects when different powerups are activated

                switch(powerupStatus.powerupChoice){

                    // Normal tap effect

                    case 0:
                        Instantiate(normalTapEffect,touchPosition,Quaternion.identity);
                        break;

                    // Laser powerup tap effect

                    case 1:
                        Instantiate(laserTapEffect,touchPosition,Quaternion.identity);
                        Instantiate(laserParticleSystem,touchPosition,Quaternion.identity);
                        break;

                    // Explosive tap effect

                    case 2:
                        Instantiate(explosionTapEffect,touchPosition,Quaternion.identity);
                        Instantiate(explosionParticleSystem,touchPosition,Quaternion.identity);
                        break;

                    // Heal tap effect

                    case 3:
                        Instantiate(healTapEffect,touchPosition,Quaternion.identity);
                        Instantiate(healParticleSystem,touchPosition,Quaternion.identity);
                        CameraShakeEffect.Instance.ScreenShake(1f,0.3f);
                        break;


                }

                
                

                if((Time.time - lastTapTime <= doubleTapThreshold) && (selfCollider == touchedCollider) && (statsRef.gameCurrency > specialAttackCost) && (isUsingSpecialAttack == false)){
                    statsRef.gameCurrency -= specialAttackCost;
                    transform.rotation = Quaternion.identity;   // Restore the rotation of the defensive core
                    SpecialAttack();
                    isUsingSpecialAttack = true;
                    animator.SetBool("isCharged", true);
                    lastTapTime = 0;

                }

                else{
                    lastTapTime = Time.time;
                }

            }

            if(touch.phase == TouchPhase.Stationary){


                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

                if((selfCollider == touchedCollider) && (powerupStatus.powerupChoice == 3) && (coreHealthRef.coreHealth < 100)){
                    // Add game juice here for healing effect 
                    
                    coreHealthRef.coreHealth += 3f * Time.deltaTime;
                }


            }

        }


    } 

    
    // Special attack indicator

    protected virtual void SpecialAttackIndicator(){

        // Indicator that you can use the special attack
        // Also add game juice here

        if((statsRef.gameCurrency > specialAttackCost)&& (isUsingSpecialAttack == false)){
            transform.Rotate(0f, 0f, 270 * Time.deltaTime);
            animator.SetBool("isCharged", true);
        }
        else{
            animator.SetBool("isCharged", false);
        }
        

    }

    // Special attack abstract function

    protected abstract void SpecialAttack();

    
}
