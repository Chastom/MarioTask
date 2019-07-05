using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int startTimeSeconds = 400;
    public Text scoreText;
    public Text coinText;
    public Text timeText;

    private float currentTime = 0;
    private int score = 0;
    private int coins = 0;
    private int lastTimeDigit = 0;

    private int goombaKillSpreeCounter = 0;
    private float goombaLastKillTimer = 0;
    private bool lvlFinished = false;

    void Awake()
    {
        currentTime = startTimeSeconds;
    }

    void Update()
    {
        if (!lvlFinished)
        {
            currentTime = currentTime - Time.deltaTime;
            goombaLastKillTimer = goombaLastKillTimer + Time.deltaTime;

            if (currentTime <= 0)
            {
                SceneManager.LoadScene("Level1");
            }
        }
        //setting UI text to current data
        scoreText.text = score.ToString("D6");
        coinText.text = coins.ToString("D2");
        timeText.text = ((int)Math.Truncate(currentTime)).ToString("D3");
    }
    ////GETS///////////////////////
    public float GetCurrentTime()
    {
        return currentTime;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetLastDigit()
    {
        return lastTimeDigit;
    }

    ////OTHER METHODS///////////////
    public void Goomba()
    {
        if (goombaLastKillTimer > 0.5f) //If Goomba was killed more than 0.5 seconds ago, we don't care about it
            goombaKillSpreeCounter = 0;

        score += (100 * (2 * goombaKillSpreeCounter)); //More killing, more score

        if (goombaKillSpreeCounter == 0) //Score that we add if no Goomba was killed in the last 0.5 seconds
            score += 100;

        goombaKillSpreeCounter++;
        goombaLastKillTimer = 0f;
    }

    public void Mushroom()
    {
        score += 1000;
    }

    public void Coin()
    {
        score += 200;
        coins++;
    }

    public void Brick()
    {
        score += 50;
    }

    public void TimeBonus()
    {
        score += 50;
    }

    public void SetFinishTime()
    {
        lvlFinished = true;
        lastTimeDigit = (int)Math.Truncate(currentTime) % 10;
    }

    public void FireworkBonus()
    {
        lastTimeDigit--;
        score += 500;
        if (lastTimeDigit > 0)
        {
            Invoke("FireworkBonus", 0.5f);
        }
    }

    public void CountFinalScore()
    {
        if (Math.Truncate(currentTime) > 0)
        {
            currentTime--;
            TimeBonus();
            Invoke("CountFinalScore", 0.02f);
        }
    }
}
