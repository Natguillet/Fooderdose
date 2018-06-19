using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class Ingredient : ScriptableObject, IFood {

    private new string name;
    private int points;
    public Sprite artwork;

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

    public int getPoints() {
        return points;
    }

    public void Print()
    {
        Debug.Log(Name + ": " + points + " points");
    }
}
