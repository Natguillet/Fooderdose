using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        speed = GetComponentInParent<Travelator>().SpeedTravelator;
        transform.Translate(Vector2.right * Time.deltaTime * speed);
	}
}
