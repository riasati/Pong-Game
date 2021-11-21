using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class CubeBallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isNewRound = true;
    public GameManagerScript gm; 
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.freezeGame == true)
        {
            return;
        }
        if (isNewRound)
        {
            CenterPositionOfBall();
            AddForce(gm.roundNumber);
        }
    }

    public void CenterPositionOfBall()
    {
        Random rnd = new Random();
        double min = -3;
        double max = +3;
        double range = max - min;
        double sample = rnd.NextDouble();
        double scaled = (sample * range) + min;
        transform.position = new Vector3(0, (float) scaled, 0);
    }

    public void AddForce(int roundNumber)
    {
        Random rnd = new Random();
        double min = 100;
        double max = 150;
        double range = max - min;
        double sample = rnd.NextDouble();
        double scaled = (sample * range) + min;
        min = 150;
        max = 200;
        range = max - min;
        double sample2 = rnd.NextDouble();
        double scaled2 = (sample * range) + min;
        if (roundNumber % 2 == 0)
        {
            scaled2 = -1 * scaled2;
        }
        Debug.Log(scaled);
        Debug.Log("--");
        Debug.Log(scaled2);
        Debug.Log("----");
        rb.AddForce(transform.up * (float) scaled * speed + transform.right * (float) scaled2 * speed,ForceMode2D.Force);
        rb.velocity = new Vector2(gm.roundNumber, gm.roundNumber);
        isNewRound = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerDeathZone"))
        {
            gm.roundNumber = gm.roundNumber + 1;
            gm.playerLives = gm.playerLives - 1;
            if (gm.playerLives <= 0)
            {
                gm.GameEnd(false);
            }

            gm.opponentScore = gm.opponentScore + 1;
            gm.UpdateScores();
            isNewRound = true;
        }

        if (other.CompareTag("OpponentDeathZone"))
        {
            gm.roundNumber = gm.roundNumber + 1;
            gm.playerScore = gm.playerScore + 1;
            gm.UpdateScores();
            isNewRound = true;
        }
    }
}
