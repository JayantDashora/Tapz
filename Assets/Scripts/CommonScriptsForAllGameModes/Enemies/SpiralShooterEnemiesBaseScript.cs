using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShooterEnemiesBaseScript : ShooterEnemiesBaseScript
{
    // Variables 

    private bool isInsideOrbit = false;
    [SerializeField] private float rotationalSpeed;
    private Vector3 center = new Vector3(0,0,0);
    [SerializeField] private float orbitRadius;

    // Functions 

    override protected void Update()
    {
        UserInput();
        CheckHealth();
        CheckOffbounds();

        if(isInsideOrbit == false){
            MoveTowardsCore();
        }

        if(isInsideOrbit == true){
            RevolveAroundCore();
        }
        
        CheckDistanceFromCore();
    }

    // Checking whether the enemy has reached the distance to spiral

    private void CheckDistanceFromCore(){
        if(Vector3.Distance(center, transform.position) <= orbitRadius){
            isInsideOrbit = true;
        }       
    }



    // Revolve around core

    private void RevolveAroundCore(){
        transform.LookAt(screenCenter, Vector3.forward);
        transform.RotateAround(center, Vector3.forward, rotationalSpeed * Time.deltaTime);
    }
}
