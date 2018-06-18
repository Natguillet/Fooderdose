using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour {

    // Use this for initialization
    private bool inRange = false; // detect if the food can be eat or not
    private Player player;
    private Score score;
        void Start () {
        GameObject scoreGameObject = GameObject.FindWithTag("Score");
        if (scoreGameObject != null) score = scoreGameObject.GetComponent<Score>();
        else Debug.Log("Cannot find score GameObject");
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        if (playerGameObject != null) player = playerGameObject.GetComponent<Player>();
        else Debug.Log("Cannot find player GameObject");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && inRange) // if the player hit space and the food is in range, destroy the food
        {
            if (gameObject.GetComponent<IngredientDisplay>().ingredient.getPoints() < 0)
            {
                score.ResetEatStreak();
                player.ChangeHumor("puke");
            }
            else
            {
                score.AddEatStreak();
                player.ChangeHumor("happy");
            }
            score.AddScore(gameObject.GetComponent<IngredientDisplay>().ingredient.getPoints());
            Destroy(gameObject);
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
