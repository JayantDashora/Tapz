using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCoreScript : MonoBehaviour
{
    // Variables

    [SerializeField] private float lifetime;
    [SerializeField] private float delayBeforeHide;

    private Vector3 hidePosition = new Vector3(-32f,0,0);
    private Vector3 center = new Vector3(0,0,0);

    private DefensiveCore5Script coreScriptRef;
    private Animator coreAnimator;
    private GameObject coreRef;


    void Start(){
        coreRef = GameObject.FindWithTag("Core");
        coreScriptRef = coreRef.GetComponent<DefensiveCore5Script>();
        coreAnimator = coreRef.GetComponent<Animator>();
        Gamejuice();
        Invoke("Hide", delayBeforeHide);
        Invoke("SelfDestruct", lifetime);
    }

    // Hide function 

    private void Hide(){
        coreRef.transform.position = hidePosition;
    }

    // Game juice

    private void Gamejuice(){
        // Add game juice here (Some sort of big particle explosion)
        coreAnimator.SetTrigger("fade");
    }

    // Destroy gameobject 
    private void SelfDestruct(){
        // Add game juice here
        coreRef.transform.position = center;
        coreAnimator.SetTrigger("fadeIn");
        coreScriptRef.isUsingSpecialAttack = false;
        Destroy(gameObject);
    }
}
