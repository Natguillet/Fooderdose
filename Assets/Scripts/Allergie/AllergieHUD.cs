using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllergieHUD : MonoBehaviour {

    [SerializeField] private Text allergieText;
    [SerializeField] private Player player;
    [SerializeField] private Sprite allergieSprite;
    [SerializeField] private GameObject allergieObject;

    // Use this for initialization
    void Start () {
        allergieSprite = null;
        allergieObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetAllergie() != null)
        {
            //allergieSprite = asprite;
            allergieObject.SetActive(true);

            allergieText.text = "Allergie : " + player.GetAllergie();
            //Debug.Log(player.GetAllergie());
        }
        else allergieObject.SetActive(false);

    }
}
