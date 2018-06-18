using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishDisplay : MonoBehaviour {

    public Dish dish;

    public SpriteRenderer artworkImage;
    public List<SpriteRenderer> ingredientImage;

	// Use this for initialization
	void Start () {
        artworkImage.sprite = dish.artwork;
        for (int i = 0; i < dish.ingredients.Count; i++) {
            ingredientImage[i].sprite = dish.ingredients[i].Artwork;
            ingredientImage[i].transform.parent.gameObject.SetActive(true);
        }
    }
}
