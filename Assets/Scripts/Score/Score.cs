using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int scoring = 0;
    private int multiplicateur = 1;
    private int eatStreak = 0;
    private int highScore = 0;
    string highScoreKey = "HighScore";

    public int Scoring
    {
        get
        {
            return scoring;
        }

        set
        {
            scoring = value;
        }
    }

    // Use this for initialization
    void Start () {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
	}
	
	// Update is called once per frame
	void Update () {
        CalculateMultiplicateur();
        if (scoring > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, scoring);
            PlayerPrefs.Save();
        }
    }

    public void AddScore(int scoreValue)
    {
        Debug.Log(scoreValue);
        if (scoreValue > 0) scoring = scoring + (scoreValue * multiplicateur);
        else scoring = scoring + scoreValue;
    }

    public void AddEatStreak()
    {
        eatStreak++;
    }

    public int GetScore()
    {
        return scoring;
    }

    public int GetMultiplicateur()
    {
        return multiplicateur;
    }

    public void ResetEatStreak()
    {
        eatStreak = 0;
    }

    public void CalculateMultiplicateur()
    {
        switch(eatStreak)
        {
            case 0:
                multiplicateur = 1;
                break;
            case 3:
                multiplicateur = 2;
                break;
            case 6:
                multiplicateur = 3;
                break;
            case 10:
                multiplicateur = 4;
                break;
            case 15:
                multiplicateur = 5;
                break;
        }
    }

}
