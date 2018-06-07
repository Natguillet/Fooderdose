using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour {

    // Use this for initialization
    private bool inRange = false; // detect if the food can be eat or not
    //[SerializeField] private Score score;
    private Score score;
    void Start () {
        GameObject scoreGameObject = GameObject.FindWithTag("Score");
        if (scoreGameObject != null) score = scoreGameObject.GetComponent<Score>();
        else Debug.Log("Cannot find score GameObject");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && inRange) // if the player hit space and the food is in range, destroy the food
        {
            Destroy(gameObject);
            score.AddScore(1);
            score.AddEatStreak();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayerRange") inRange = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayerRange") inRange = false;
    }
}
