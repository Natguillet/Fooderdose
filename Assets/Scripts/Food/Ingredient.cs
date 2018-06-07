using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class Ingredient : ScriptableObject {

    public new string name;
    public int points;
    public Sprite artwork;

    public void Print()
    {
        Debug.Log(name + ": " + points + " points");
    }
}
