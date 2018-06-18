using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientDisplay : MonoBehaviour {

    public Ingredient ingredient;

    public SpriteRenderer artworkImage;

    // Use this for initialization
    void Start () {
        artworkImage.sprite = ingredient.Artwork;
	}
}
