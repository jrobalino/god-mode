using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

	// This script handles unlocking achievements when mushrooms are placed on the rich or poor tables

	Vector3 startPosition;
	Quaternion startRotation;

	public FoodManager foodManager;

	// Use this for initialization
	void Start()
	{
		// Get the start position of the bowl
		startPosition = transform.position;
		startRotation = transform.rotation;
	}

	// Update is called once per frame
	void Update()
	{

		// Return the mushroom to its starting position and disable it if the player tosses it over the edge
		if (transform.position.y < -25)
		{
			transform.gameObject.SetActive(false);
			transform.position = startPosition;
			transform.rotation = startRotation;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{

		// Detect whether the mushroom was placed on the rich or poor table and call the corresponding achievement function
		if (collision.collider.name == "RichTable")
		{
			foodManager.unlockAchievement(0);
		}

		if (collision.collider.name == "PoorTable")
		{
			foodManager.unlockAchievement(1);
		}
	}

}
