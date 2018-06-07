using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int scoring = 0;
    private int multiplicateur = 1;
    private int eatStreak = 0;

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
		
	}
	
	// Update is called once per frame
	void Update () {
        CalculateMultiplicateur();
	}

    public void AddScore(int scoreValue)
    {
        scoring  = scoring + (scoreValue * multiplicateur);
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
