using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreScript : MonoBehaviour
{

    // Variables

    void Start(){
        GetComponent<TMP_Text>().text = "HIGHSCORE "+ PlayerPrefs.GetInt("HIGHSCORE").ToString(); 
    }

}
