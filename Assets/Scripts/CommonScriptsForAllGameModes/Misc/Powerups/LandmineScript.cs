using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineScript : MonoBehaviour
{
    // Variables

    [SerializeField] private float explosionRange;
    [SerializeField] private ParticleSystem explosion;

    private Collider2D[] enemiesInRange;

    // Checking collisions

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("Enemy")){
            // Add game juice here

            enemiesInRange = Physics2D.OverlapCircleAll(transform.position, explosionRange);

            foreach(Collider2D enemy in enemiesInRange){
                
                if(enemy.gameObject.CompareTag("Enemy")){

                    // Add game juice here

                    Destroy(enemy.gameObject);
                    CameraShakeEffect.Instance.ScreenShake(5f,0.2f);
                    Instantiate(explosion,transform.position,Quaternion.identity);
                    Destroy(gameObject);
                }
                
            }
        }
    }

}
