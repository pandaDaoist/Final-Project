using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Text scoreText, timeText, splashText;

	// Use this for initialization
	void Start () {
        splashText.text = "LAND!";
        scoreText.text = "0";
        timeText.text = "10";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private Counter ()
    {

    }
}
