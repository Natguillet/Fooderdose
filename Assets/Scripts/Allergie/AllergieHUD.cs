using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllergieHUD : MonoBehaviour {

    [SerializeField] private Text allergieText;
    [SerializeField] private Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetAllergie() != null)
        {
            allergieText.text = "Allergie : " + player.GetAllergie();
            Debug.Log(player.GetAllergie());
        }
	}
}
