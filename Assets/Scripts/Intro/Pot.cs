using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
	// This script plays sounds and checks the player's progress as they toss pots in the intro level

	public AudioSource goodJob;
	public IntroManager introManager;

	Vector3 startPosition;
	Quaternion startRotation;

	// Use this for initialization
	void Start()
	{
		// Get the starting position of the pot
		startPosition = transform.position;
		startRotation = transform.rotation;

	}

	// Update is called once per frame
	void Update()
	{
		// Play an affirming sound if the player tosses the pot off the island
		if (transform.position.y < -1 && transform.position.y > -1.1)
		{
			goodJob.Play();
		}

		// Prevent the pot from falling forever
		if (transform.position.y < -25)
		{
			killPot();
		}
	}

	void killPot()
	{
		// Return the pot to its starting position, deactivate it, and check whether the player has completed the level
		gameObject.SetActive(false);
		transform.position = startPosition;
		transform.rotation = startRotation;
		introManager.checkPots();
	}
}


