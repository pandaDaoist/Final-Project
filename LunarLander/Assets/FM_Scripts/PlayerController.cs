using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Text scoreText, timeText, splashText;
    private int timer;
    private Rigidbody2D rb2d;

    public int speed;

	// Use this for initialization
	void Start () {
        splashText.text = "LAND!";
        scoreText.text = "0";
        timeText.text = "10";
        timer = 0;
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (timer >= 10)
        {
            splashText.text = "You Lose! :(";
            StartCoroutine(ByeAfterDelay(2));

        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        //GameLoader.gameOn = false;
    }


}
