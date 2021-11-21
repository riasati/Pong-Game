using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GameManagerScript : MonoBehaviour
{
    public GameObject cubeBall;

    public bool isNewRound = true;
    public bool freezeGame = false;
    public int playerLives = 3;
    public int playerScore = 0;
    public int opponentScore = 0;
    public Text playerScoreText;
    public Text OpponentScoreText;
    public Text playerWinText;
    public Text OpponentWinText;

    public int roundNumber = 1;

    public void instantiateNewCubeBall()
    {
        Random rnd = new Random();
        double min = -3;
        double max = +3;
        double range = max - min;
        double sample = rnd.NextDouble();
        double scaled = (sample * range) + min;
        Instantiate(cubeBall.transform,new Vector3(this.transform.position.x,this.transform.position.y + (float)scaled,this.transform.position.z),this.transform.rotation);
        cubeBall.gameObject.GetComponent<CubeBallScript>().AddForce(roundNumber);
        isNewRound = false;
    }

    public void GameEnd(bool isPlayerWin)
    {
        freezeGame = true;
        if (isPlayerWin)
        {
            playerWinText.gameObject.SetActive(true);
        }
        else
        {
            OpponentWinText.gameObject.SetActive(true);
        }
    }

    public void UpdateScores()
    {
        playerScoreText.text = playerScore.ToString();
        OpponentScoreText.text = opponentScore.ToString();
        if (playerScore >= 5)
        {
            GameEnd(true);
        }
        if (opponentScore >= 5)
        {
            GameEnd(false);
        }
    }
}
