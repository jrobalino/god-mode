using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour {

	// This script handles bowls being tossed off the island and signals the FoodManager script when bowls are placed or removed from tables

	Vector3 startPosition;
	Quaternion startRotation;

	public FoodManager foodManager;
	
	// Use this for initialization
	void Start () {
		// Get the start position of the bowl
		startPosition = transform.position;
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		// Return the bowl to its starting position if the player tosses it over the edge
		if (transform.position.y < -25)
		{
			transform.position = startPosition;
			transform.rotation = startRotation;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{

		// Detect whether the bowl was placed on the rich or poor table
		if (collision.collider.name == "RichTable")
		{
			foodManager.feedTheRich();
		}

		if (collision.collider.name == "PoorTable")
		{
			foodManager.feedThePoor();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		// Detect whether the bowl was taken away from the rich or poor table
		if (collision.collider.name == "RichTable")
		{
			foodManager.starveTheRich();
		}

		if (collision.collider.name == "PoorTable")
		{
			foodManager.starveThePoor();
		}
	}
}
