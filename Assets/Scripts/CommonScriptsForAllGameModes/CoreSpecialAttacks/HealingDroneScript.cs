using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDroneScript : MonoBehaviour
{

    // Variables

    [SerializeField] private float healthIncreasedPerSecond;
    private Vector3 center = new Vector3(0,0,0);
    
    // The path is set up using lerping

    // Starting and ending points
    private Vector3 spawnPoint = new Vector3(-4f,0,0);
    private Vector3 targetPoint = new Vector3(-0.7f,0,0);

    private Vector3 destroyPoint = new Vector3(-6f,0,0);

    // Intermediate Points
    private Vector3 iPoint1 = new Vector3(-2f,1,0);
    private Vector3 iPoint2 = new Vector3(-2f,-1,0);

    private float interpolateAmountEnter;
    private float interpolateAmountExit;

    private DefensiveCore3Script coreScriptRef;
    private CoreHealth coreHealthRef;

    private SpriteRenderer sprite;

    [SerializeField] private GameObject healEffect;
    [SerializeField] private float healEffectFrequency;

    [SerializeField] private ParticleSystem healParticleEffect;

    private float timer;


    void Start()
    {
        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<DefensiveCore3Script>();
        coreHealthRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
        sprite = GetComponent<SpriteRenderer>();
        Invoke("EnterScreen",0.1f);
    }

    void Update()
    {
        EnterScreen();
        CheckReturnStatus();
        HealCore();
        Destruct();
    }

    private void HealCore(){
        float distanceToCenter = Vector3.Distance(transform.position, center);
        if (distanceToCenter <= 0.8f){
            // Add game juice here

            if(timer > healEffectFrequency){
                Instantiate(healParticleEffect,center,Quaternion.identity);
                Instantiate(healEffect,center,Quaternion.identity);
                timer = 0; 
            }

            timer += Time.deltaTime;

            float healAmount = healthIncreasedPerSecond * Time.deltaTime;
            coreHealthRef.coreHealth += healAmount;
        }
    }

    private void CheckReturnStatus(){
        if(coreHealthRef.coreHealth >= 100){
            coreHealthRef.coreHealth = 100;
            ExitScreen();
        }
    }

    private void Destruct(){
        if(transform.position.x < -5.5f){
            // Add game juice here
            coreScriptRef.isUsingSpecialAttack = false;
            Destroy(gameObject);
        }
    }

    private void EnterScreen(){
        sprite.flipX = false;
        interpolateAmountEnter += (interpolateAmountEnter + Time.deltaTime) % 0.03f;
        transform.position = Vector3.Lerp(Vector3.Lerp(spawnPoint,iPoint1,interpolateAmountEnter),Vector3.Lerp(iPoint1,targetPoint,interpolateAmountEnter),interpolateAmountEnter);
    }

    private void ExitScreen(){
        sprite.flipX = true;
        interpolateAmountExit += (interpolateAmountExit + Time.deltaTime) % 0.03f;
        transform.position = Vector3.Lerp(Vector3.Lerp(targetPoint,iPoint2,interpolateAmountExit),Vector3.Lerp(iPoint2,destroyPoint,interpolateAmountExit),interpolateAmountExit);
    }

}
