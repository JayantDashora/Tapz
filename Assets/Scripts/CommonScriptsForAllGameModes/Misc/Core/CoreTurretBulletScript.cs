using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreTurretBulletScript : MonoBehaviour
{
    // Variables

    [SerializeField] private float speed;
    private Rigidbody2D rb;


    // Functions

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = speed * transform.up;
    }

    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.CompareTag("Enemy")){

            // Damaging the enemy
            // Add game juice here
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        else{
            Destroy(gameObject);
        }

    } 
}
