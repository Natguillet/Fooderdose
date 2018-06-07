using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientDisplay : MonoBehaviour {

    public Ingredient ingredient;

    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = ingredient.artwork;
	}
}
