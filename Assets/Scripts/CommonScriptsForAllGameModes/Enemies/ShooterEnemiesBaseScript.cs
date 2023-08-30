using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemiesBaseScript : BasicEnemy
{

    // Variables

    [SerializeField] private float shootFrequency;
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform particlePoint;
    [SerializeField] private ParticleSystem particleEffect;

    private Animator animator;

    // Functions

    override protected void Start(){

        selfCollider = GetComponent<Collider2D>();
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
        powerupStatus = GameObject.Find("GameManagers/PowerupStatusManager").GetComponent<PowerupStatusManagerScript>();
        animator = GetComponent<Animator>();
        uiManager = GameObject.Find("GameManagers/GameUIManager").GetComponent<GameUIManagerScript>();
        fadeEffectAnimator = GameObject.Find("UI/Canvas/FlashEffect").GetComponent<Animator>();
        
        // Invoke the shooting nature of the enemy
        InvokeRepeating("ShootAtCore", 0.1f, shootFrequency);
    }

    private void ShootAtCore(){

        if(animator != null){
            animator.SetTrigger("shoot");
        }

        CameraShakeEffect.Instance.ScreenShake(3f,0.1f);
        Instantiate(particleEffect,particlePoint.position,Quaternion.identity);
        Instantiate(bullet, shootPoint.position, transform.rotation);

    }

    override protected void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Core")){
            coreHealthScriptRef.coreHealth -= enemyDamage; // Damaging the core
            uiManager.PopCoreHealthUI();
            CameraShakeEffect.Instance.ScreenShake(5f,0.3f);
            fadeEffectAnimator.SetTrigger("flash");
            
            Destruct();
        }
    }


}
