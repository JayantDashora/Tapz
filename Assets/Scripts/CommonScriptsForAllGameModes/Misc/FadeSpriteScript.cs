using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSpriteScript : MonoBehaviour
{

    // Variables 

    [SerializeField] private Vector3 center = new Vector3(0,0,0);
    [SerializeField] private Vector3 otherPosition = new Vector3(20,0,0);
    [SerializeField] private float timeDuration = 5;

    // Update is called once per frame
    void Update()
    {
        // Check whether it is activated or not
        if(transform.position == center){
            Invoke("DeactivateBlackout", timeDuration);
        }
    }

    // Deactivate the blackout effect
    private void DeactivateBlackout(){
        transform.position = otherPosition;
    }
}
