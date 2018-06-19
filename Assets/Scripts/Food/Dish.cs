using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dish", menuName = "Dish")]
public class Dish : ScriptableObject, IFood
{

    public new string name;
    public Sprite artwork;

    public List<Ingredient> ingredients;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public void Print()
    {
        Debug.Log(Name + ": " + getPoints() + " points");
    }

    public int getPoints() {
        int totalPoints = 0;
        foreach (Ingredient ingredient in ingredients) {
            totalPoints += ingredient.getPoints();
        }
        return totalPoints;
    }
}
