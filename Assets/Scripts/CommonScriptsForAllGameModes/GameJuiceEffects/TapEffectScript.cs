using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffectScript : MonoBehaviour
{
    // Variables 

    [SerializeField] private float lifetime;
    
    private Vector3 finalSize = new Vector3(20f,20f,20f);

    private float interpolateAmount; 

    private void Update() {

        interpolateAmount += (interpolateAmount + Time.deltaTime) % 0.03f;
        transform.localScale = Vector3.Lerp(Vector3.zero, finalSize, interpolateAmount);

        lifetime -= Time.deltaTime;

        if(lifetime <= 0){
            Destroy(gameObject);
        }

    }
    
}
