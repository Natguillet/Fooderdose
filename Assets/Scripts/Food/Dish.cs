using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dish", menuName = "Dish")]
public class Dish : ScriptableObject {

    public new string name;
    public Sprite artwork;

    public List<Ingredient> ingredients;

    public void Print()
    {
        Debug.Log(name + ": " + getPoints() + " points");
    }

    public int getPoints() {
        int totalPoints = 0;
        foreach (Ingredient ingredient in ingredients) {
            totalPoints += ingredient.points;
        }
        return totalPoints;
    }
}
