using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveCore3Script : CoreAbstractClass
{
    // Variables

    [SerializeField] private GameObject coreTurret;

    [SerializeField] private ParticleSystem particleEffect;

    private Vector3 spawnPoint1 = new Vector3(0,1.3f,0);
    private Vector3 spawnPoint2 = new Vector3(-1,-1,0);
    private Vector3 spawnPoint3 = new Vector3(1,-1,0);

    // Special Attack

    protected override void SpecialAttack(){
        // Add game juice here 

        CameraShakeEffect.Instance.ScreenShake(5f,0.2f);
        Instantiate(particleEffect, spawnPoint1, Quaternion.identity);
        Instantiate(coreTurret, spawnPoint1, transform.rotation);

        CameraShakeEffect.Instance.ScreenShake(5f,0.2f);
        Instantiate(particleEffect, spawnPoint2, Quaternion.identity);
        Instantiate(coreTurret, spawnPoint2, transform.rotation);

        CameraShakeEffect.Instance.ScreenShake(5f,0.2f);
        Instantiate(particleEffect, spawnPoint3, Quaternion.identity);
        Instantiate(coreTurret, spawnPoint3, transform.rotation);
        
    }

    // Special attack indicator

    protected override void SpecialAttackIndicator(){

        // Indicator that you can use the special attack
        // Also add game juice here

        if((statsRef.gameCurrency > specialAttackCost)&& (isUsingSpecialAttack == false)){
            animator.SetBool("isCharged", true);
        }
        else{
            animator.SetBool("isCharged", false);
        }
        

    }
}
