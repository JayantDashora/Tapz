using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    // Variables

    [SerializeField] private float speed;
    [SerializeField] private float projectileDamage;
    private Rigidbody2D rb;
    private CoreHealth coreHealthScriptRef;

    // Functions

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
    }
    void Update()
    {
        rb.velocity = speed * transform.forward;
    }

    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.CompareTag("Core")){

            // Damaging the core
            coreHealthScriptRef.coreHealth -= projectileDamage;
            Destroy(gameObject);

        }
        else{
            Destroy(gameObject);
        }

    } 
}
