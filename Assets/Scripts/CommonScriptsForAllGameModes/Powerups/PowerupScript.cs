using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    // Variables 

    private float lastTapTime = 0f;
    private float doubleTapThreshold = 0.3f;
    protected Vector3 hideSpot = new Vector3(32,0,0);

    private Collider2D selfCollider;
    private Animator animator;

    protected PowerupStatusManagerScript powerupStatus;

    [SerializeField] protected int powerupNumber;
    [SerializeField] protected float lifetime;

    [SerializeField] private string instructionsText;

    private GameUIManagerScript uiManager;

    // Functions

    private void Start() {

        powerupStatus = GameObject.Find("GameManagers/PowerupStatusManager").GetComponent<PowerupStatusManagerScript>();
        selfCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        uiManager = GameObject.Find("GameManagers/GameUIManager").GetComponent<GameUIManagerScript>();

    }

    private void Update() {
        // Take user input 
        UserInput();
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

                if((Time.time - lastTapTime <= doubleTapThreshold) && (selfCollider == touchedCollider)){
                    Powerup();
                }

                else{
                    lastTapTime = Time.time;
                }
            }

        }


    } 

    // Powerup function
    
    protected virtual void Powerup(){
        // Add game juice in this function

        uiManager.ShowPowerupInstructions(instructionsText,lifetime - 1);
        animator.SetTrigger("click");

        powerupStatus.powerupChoice = powerupNumber;
        Invoke("Hide", 0.5f);
        Invoke("SelfDestruct", lifetime);
    }

    private void Hide(){
        transform.position = hideSpot;
    }

    // Destroy gameobject 

    protected void SelfDestruct(){
        // Add game juice here
        powerupStatus.powerupChoice = 0;
        Destroy(gameObject);
    }
}
