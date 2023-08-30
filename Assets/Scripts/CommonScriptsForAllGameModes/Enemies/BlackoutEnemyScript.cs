using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutEnemyScript : BasicEnemy
{

    // Variables
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float fadeDuration;
    private GameObject fadeSprite;
    private Animator fadeSpriteAnimator;

    private SpriteRenderer sprite;

    // Functions

    override protected void Start(){
        selfCollider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        fadeSprite = GameObject.Find("UI/Canvas/FadeEffect");
        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
        powerupStatus = GameObject.Find("GameManagers/PowerupStatusManager").GetComponent<PowerupStatusManagerScript>();
        uiManager = GameObject.Find("GameManagers/GameUIManager").GetComponent<GameUIManagerScript>();
        fadeSpriteAnimator = fadeSprite.GetComponent<Animator>();
        fadeEffectAnimator = GameObject.Find("UI/Canvas/FlashEffect").GetComponent<Animator>();
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
            uiManager.PopCoreHealthUI();
            fadeEffectAnimator.SetTrigger("flash");
            Instantiate(destructEffect, transform.position, transform.rotation);
            CameraShakeEffect.Instance.ScreenShake(5f,0.3f);
            Blackout();
            sprite.enabled = false;
        }
    }

    // Blackout the screen
    private void Blackout(){

       fadeSprite.SetActive(true);
       fadeSpriteAnimator.SetTrigger("fade");
       Invoke("BlackoutEnd",fadeDuration);
    }

    private void BlackoutEnd(){
        fadeSpriteAnimator.SetTrigger("fadeIn");
        Destruct();
    }
}
