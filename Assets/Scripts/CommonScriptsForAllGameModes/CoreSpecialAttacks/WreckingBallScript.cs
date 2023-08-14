using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float senseRadius;
    [SerializeField] private float rotationalSpeed;
    [SerializeField] private float orbitRadius;
    [SerializeField] private float lifetime;

    private bool canKill = false;
    private Collider2D target;

    private Vector3 screenCenter = new Vector3(0,0,0);

    private OffensiveCore2Script coreScriptRef;

    private void Start() {
        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<OffensiveCore2Script>();
        Invoke("SelfDestruct", lifetime);
    }

    private void Update() {
        if(canKill == false){

            // Return to the core to defend it
            if(Vector3.Distance(transform.position, screenCenter) >= orbitRadius){
                transform.position = Vector2.MoveTowards(transform.position, screenCenter, speed * Time.deltaTime);
            }
            else{
                transform.RotateAround(screenCenter, Vector3.forward, rotationalSpeed * Time.deltaTime);
            }

            // Search for enemies in range

            target = Physics2D.OverlapCircle(transform.position,senseRadius);

            if(target.gameObject.CompareTag("Enemy")){
                canKill = true;
            }

        }
        else{
            // Add game juice here
            Vector3 targetPos = target.gameObject.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    // Checking collisions and killing enemies

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            // Add game juice here
            canKill = false;
            Destroy(other.gameObject);
        }
    }

    // Destroy gameobject 

    private void SelfDestruct(){
        // Add game juice here
        coreScriptRef.isUsingSpecialAttack = false;
        Destroy(gameObject);
    }

}
