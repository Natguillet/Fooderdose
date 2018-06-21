using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Travelator : MonoBehaviour {

    [SerializeField] private float speedTravelator = 1f;
    [SerializeField] private float interval = 1f;
    [SerializeField] private GameObject ingredient;
    [SerializeField] private GameObject dish;
    private List<IFood> foods = new List<IFood>();
    private Transform spawnPoint;
    private int timer = 2;

    public float SpeedTravelator
    {
        get
        {
            return speedTravelator;
        }

        set
        {
            speedTravelator = value;
        }
    }

    // Use this for initialization
    void Start () {
        LoadFoods();
        spawnPoint = GetComponentInChildren<Transform>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true) {
            speedTravelator = 3*Mathf.Log(5* timer,10);
            timer++;
            // Create an instance of the food prefab at the spawn point's position and rotation.
            IFood obj = foods[Random.Range(0, foods.Count)];
            GameObject newFood;
            /*
            if (obj is Ingredient)
            {
                newFood = Instantiate(ingredient, spawnPoint.position, spawnPoint.rotation);
                newFood.GetComponent<IngredientDisplay>().ingredient = obj as Ingredient;
            }
            else {
            */
            newFood = Instantiate(dish, spawnPoint.position, spawnPoint.rotation);
            newFood.GetComponent<DishDisplay>().dish = obj as Dish;
            //}
            newFood.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(interval / speedTravelator);
            Debug.Log(true);
        }
    }

    private void LoadFoods()
    {
        Object[] ressources = Resources.LoadAll("", typeof(IFood));

        //Debug.Log(ressources.Length + "Assets");
        foreach (var t in ressources) {
            if((t as IFood) is Dish)  foods.Add(t as IFood);
            //Debug.Log(t.name);
        }
    }
}
