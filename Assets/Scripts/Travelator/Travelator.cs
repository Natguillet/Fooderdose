using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Travelator : MonoBehaviour {

    [SerializeField] private float speedTravelator = 1f;
    [SerializeField] private float interval = 1f;
    [SerializeField] private GameObject ingredient;
    [SerializeField] private GameObject dish;
    [SerializeField] private GameObject rug;
    [SerializeField] private int nbRugs;
    [SerializeField] private Transform startRug;
    [SerializeField] private Transform endRug;

    private Transform[] rugs;
    private List<IFood> foods = new List<IFood>();
    private Transform spawnPoint;
    private Transform spawnRug;
    private int timer = 2;
    private float unitFactor;

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
        spawnPoint = GetComponentInChildren<Transform>();
        unitFactor = (endRug.position.x - startRug.position.x) / nbRugs;
        rugs = new Transform[nbRugs];
        
        for (int i = 0; i < nbRugs; i++)
        {
            rugs[i] = Instantiate(rug, startRug.position + new Vector3(unitFactor * i, 0, 0), spawnPoint.rotation).transform;
        }
        
        LoadFoods();
        StartCoroutine(Spawn());
    }


    private void Update()
    {
        for (int i = 0; i < nbRugs; i++)
        {
            rugs[i].Translate(Vector2.right * Time.deltaTime * speedTravelator);
            if(rugs[i].position.x > endRug.position.x)
            {
                rugs[i].position = startRug.position;
            }
            /*
            rugs[i].position = new Vector3(startRug.position.x + ((rugs[i].position.x + speedTravelator *  - startRug.position.x) % (endRug.position.x - startRug.position.x)),
                                            startRug.position.y, startRug.position.z); 
                                            */
        }
            
    }
    
    private IEnumerator Spawn()
    {
        while (true) {
            speedTravelator = 3 * Mathf.Log(5 * timer,10);
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
