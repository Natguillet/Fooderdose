using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour {

    private string humor;
    [SerializeField] private Sprite happy;
    [SerializeField] private Sprite puke;
    private Dictionary<string, int> foodEat = new Dictionary<string, int>();
    private string allergie;
    private int fail = 0;
    private bool loose = false;

	// Use this for initialization
	void Start () {

        Object[] ressources = Resources.LoadAll("Ingredients", typeof(Ingredient));
        foreach (var t in ressources)
        {
            foodEat.Add(t.name, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        ChangeFace();
        if(fail >= 3)
        {
            loose = true;
            Debug.Log("YOU LOOSE");
        }
    }

    public void ChangeFace()
    {
        switch(humor)
        {
            case "happy":
                gameObject.GetComponent<SpriteRenderer>().sprite = happy;
                break;
            case "puke":
                gameObject.GetComponent<SpriteRenderer>().sprite = puke;
                break;
        }
    }

    public void AddCountFood(string food)
    {
        foodEat[food]++;
        ChangeAllergie(food);
    }

    public void ChangeHumor(string newHumor)
    {
        humor = newHumor;
    }

    public void ChangeAllergie(string food)
    {
        if (foodEat[food] == 3)
        {
            allergie = food;
            foodEat[food] = 0;
        }
    }

    public string GetAllergie()
    {
        return allergie;
    }

    public void AddFail()
    {
        fail++;
    }

    public void ResetFail()
    {
        fail = 0;
    }
}
