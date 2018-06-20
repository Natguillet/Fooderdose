using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour {

    [SerializeField] private Text scoreText;
    [SerializeField] private Text multiplierText;

    private Score score;
    // Use this for initialization
    void Start () {
        GameObject scoreGameObject = GameObject.FindWithTag("Score");
        if (scoreGameObject != null) score = scoreGameObject.GetComponent<Score>();
        else Debug.Log("Cannot find score GameObject");
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.GetScore() + "pts";
        multiplierText.text = "x" + score.GetMultiplicateur();
	}
}
