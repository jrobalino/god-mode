using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeper : MonoBehaviour
{
	// This script controls the minesweeper dogs

	public AudioSource fallWhine;
	public LandmineManager landmineManager;

	Vector3 startPosition;
	Quaternion startRotation;
	bool keepAnimating = true;
	bool hitMine = false;

	Animator anim;

	// Use this for initialization
	void Start()
	{
		// Get the start position of the dog
		startPosition = transform.position;
		startRotation = transform.rotation;

		// Get the animator for the dog
		anim = GetComponentInChildren<Animator>();
		startAnimations();

	}

	// Update is called once per frame
	void Update()
	{
		// Have the dog whimper if it is directed over the edge of the island
		if (transform.position.y < -1 && transform.position.y > -1.1)
		{
			fallWhine.Play();
		}

		// Prevent the dog from falling forever
		if (transform.position.y < -25)
		{
			killDog();
			// Check that the dog wasn't already killed by a mine before getting the next dog
			if (!hitMine)
			{
				landmineManager.nextDog();
			}
		}
	}

	void killDog()
	{
		// Return the dog to its starting position but make it inactive
		gameObject.SetActive(false);
		transform.position = startPosition;
		transform.rotation = startRotation;
	}

	public void blowUpDog()
	{
		// Disable the dog's animator after it hits a mine and call the LandmineManager script to disable the dog's movement and controls
		anim.enabled = false;
		hitMine = true;
		landmineManager.blowUpDog();
	}

	void startAnimations()
	{
		// Switch between the available animations at random intervals
		int random = Random.Range(0, 3);

		switch (random)
		{

			case 0:
				anim.SetTrigger("Idle");
				break;

			case 1:
				anim.SetTrigger("Bark");
				break;

			case 2:
				anim.SetTrigger("Jump");
				break;
		}

		if (keepAnimating)
		{
			Invoke("startAnimations", Random.Range(3.0f, 7.0f));
		}
		

	}
}


