using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllergieHUD : MonoBehaviour {
    
    [SerializeField] private Player player;
    [SerializeField] private Image allergieImage;
    [SerializeField] private GameObject allergieObject;

    // Use this for initialization
    void Start () {
        allergieObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetAllergie() != null)
        {
            allergieObject.SetActive(true);
            Ingredient ingredient = Resources.Load<ScriptableObject>("Ingredients/" + player.GetAllergie()) as Ingredient;
            if (ingredient != null)
            {
                allergieImage.sprite = ingredient.artwork;
            }
        }
        else allergieObject.SetActive(false);

    }
}
