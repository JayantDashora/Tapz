using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveCore2ForceFieldScript : MonoBehaviour
{
    // Variables

    [SerializeField] private float pushbackForce;
    [SerializeField] private float lifetime;

    private DefensiveCore2Script coreScriptRef;

    // Functions

    private void Start() {
        Invoke("SelfDestruct", lifetime);
        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<DefensiveCore2Script>();
    }


    // Checking collisions with the enemies
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(-other.gameObject.transform.forward * pushbackForce, ForceMode2D.Impulse);
        }
    }

    // Destroy gameobject 

    private void SelfDestruct(){
        // Add game juice here
        coreScriptRef.isUsingSpecialAttack = false;
        Destroy(gameObject);
    }
}
