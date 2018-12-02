using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UFOController : MonoBehaviour {

    public Text scoreText, timeText, splashText;
    private int timer, timeCount, score;
    private Rigidbody2D rb2d;
    private bool gameOver;

    public float speed, thrust, gravity;
    

	// Use this for initialization
	void Start () {
        splashText.text = " CRASH LAND!";
        scoreText.text = "Score: " + score.ToString();
        timeText.text = "Time: " + timer.ToString();
        timer = 10;
        score = 0;
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(CountDown());
        gameOver = false;
       
    }
	
	
	void FixedUpdate () {
        if (timer <= 0)
        {
            splashText.text = "You Lose! :(";
            speed = 0;
            StartCoroutine(ByeAfterDelay(2));
            gameLoader.Addscore(score);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space))
        {
            thrust = 1;
        }
        else
        {
            thrust = 0;
        }
        rb2d.velocity = new Vector2(moveHorizontal * speed, thrust * speed);

        if(gameOver)
        {
            StopCoroutine(CountDown());
        }

        if (Input.GetKey("escape"))
            Application.Quit();

        scoreText.text = "Score: " + score.ToString();
        timeText.text = "Time: " + timer.ToString();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "asteroid01")
        {
            splashText.text = "You Win! +" + score.ToString() + " Points!";
            score = 1;
            speed = 0;
            gameLoader.Addscore(score);
            gameOver = true;
            StartCoroutine(ByeAfterDelay(2));

        }
        if (collision.collider.tag == "asteroid02")
        {
            splashText.text = "You Win! +" + score.ToString() + " Points!";
            score = 5;
            speed = 0;
            gameLoader.Addscore(score);
            gameOver = true;
            StartCoroutine(ByeAfterDelay(2));
        }
        if (collision.collider.tag == "asteroid03")
        {
            splashText.text = "You Win! +" + score.ToString() + " Points!";
            score = 10;
            speed = 0;
            gameLoader.Addscore(score);
            gameOver = true;
            StartCoroutine(ByeAfterDelay(2));
        }
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        GameLoader.gameOn = false;
    }

    IEnumerator CountDown ()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
    }
}
