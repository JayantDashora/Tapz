using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneManEnemyScript : BasicEnemy
{
    // Variables

    [SerializeField] private GameObject specialEffect;
    [SerializeField] private ParticleSystem specialParticles;

    [SerializeField] private AudioClip blastEffect;

    private Vector3 center = new Vector3(0,0,0);

    // Checking collisions

    override protected void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Core")){
            uiManager.PopCoreHealthUI();
            CameraShakeEffect.Instance.ScreenShake(5f,0.3f);
            fadeEffectAnimator.SetTrigger("flash");
            coreHealthScriptRef.coreHealth -= enemyDamage; // Damaging the core
            
            SpecialAttack();
            Destruct();
        }
    }


    // Bomb rain when one man collides with the core 

    private void SpecialAttack(){

        // Special Attack
        Instantiate(specialParticles,center,Quaternion.identity);
        Instantiate(specialEffect,center,Quaternion.identity);
        CameraShakeEffect.Instance.ScreenShake(30f,3f);
        Handheld.Vibrate();
        GameAudioManager.instance.PlaySoundEffect(blastEffect,1f);
        fadeEffectAnimator.SetTrigger("flashWhite");
        // The special attack will have a very big explosion on the center of the screen with a lot of screen shake and other effects

    }

}
