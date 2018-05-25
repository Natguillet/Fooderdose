using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {
        speed = GetComponentInParent<Travelator>().SpeedTravelator;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
	}
}
