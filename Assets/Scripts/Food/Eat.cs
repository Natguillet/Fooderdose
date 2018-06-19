﻿using System.Collections;
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
            Debug.Log("Space");
            if (gameObject.GetComponent<IngredientDisplay>() && player.GetAllergie() == gameObject.GetComponent<IngredientDisplay>().ingredient.name
                || gameObject.GetComponent<DishDisplay>() && CheckDishAllergie())
            {
                score.ResetEatStreak();
                score.AddScore(-100);
                player.ChangeHumor("puke");
            }
            else if (gameObject.GetComponent<IngredientDisplay>())
            {
                score.AddEatStreak();
                score.AddScore(gameObject.GetComponent<IngredientDisplay>().ingredient.getPoints());
                player.ChangeHumor("happy");
                player.AddCountFood(gameObject.GetComponent<IngredientDisplay>().ingredient.name);
            }
            else if (gameObject.GetComponent<DishDisplay>())
            {
                score.AddEatStreak();
                score.AddScore(gameObject.GetComponent<DishDisplay>().dish.getPoints());
                player.ChangeHumor("happy");
                for (int i = 0; i < gameObject.GetComponent<DishDisplay>().dish.ingredients.Count; i++)
                {
                    player.AddCountFood(gameObject.GetComponent<DishDisplay>().dish.ingredients[i].name);
                }
            }

            Destroy(gameObject);
            player.ResetFail();
        }
    }

    public bool CheckDishAllergie()
    {
        bool dishAllergie = false;
        for(int i =0; i< gameObject.GetComponent<DishDisplay>().dish.ingredients.Count; i++)
        {
            if (player.GetAllergie() == gameObject.GetComponent<DishDisplay>().dish.ingredients[i].name)
            {
                dishAllergie = true;
            }
        }
        return dishAllergie;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayerRange") inRange = true;
        if (col.gameObject.name == "PlayerNoRange") player.AddFail();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayerRange")
        {
            inRange = false;
        }
    }
}