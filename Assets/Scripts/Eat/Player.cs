using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private string humor;
    [SerializeField] private Sprite happy;
    [SerializeField] private Sprite puke;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ChangeFace();
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

    public void ChangeHumor(string newHumor)
    {
        humor = newHumor;
    }
}
