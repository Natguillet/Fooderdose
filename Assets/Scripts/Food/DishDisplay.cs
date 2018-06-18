using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishDisplay : MonoBehaviour {

    public Dish dish;

    public SpriteRenderer artworkImage;

	// Use this for initialization
	void Start () {
        artworkImage.sprite = dish.artwork;
        foreach (Ingredient ingredient in dish.ingredients) {

        }

    }
}
