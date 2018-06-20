using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int scoring = 0;
    private int multiplicateur = 1;
    private int eatStreak = 0;
    private CameraMovement cameraController;

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
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        CalculateMultiplicateur();
	}

    public void AddScore(int scoreValue)
    {
        //Debug.Log(scoreValue);
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
                ChangeMultiplicateur(1);
                break;
            case 3:
                ChangeMultiplicateur(2);
                break;
            case 6:
                ChangeMultiplicateur(3);
                break;
            case 10:
                ChangeMultiplicateur(4);
                break;
            case 15:
                ChangeMultiplicateur(5);
                break;
        }
    }

    private void ChangeMultiplicateur(int m)
    {
        //cameraController.UpdateBloomEffect(m);
        multiplicateur = m;
    }

}
