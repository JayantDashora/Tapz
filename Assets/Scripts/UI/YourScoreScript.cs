using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YourScoreScript : MonoBehaviour
{
    // Variables

    void Start(){
        GetComponent<TMP_Text>().text = "YOUR SCORE : " + Data.thisGameScore.ToString(); 
    }
}
