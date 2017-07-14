using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellfirePuppy : MonoBehaviour
{
	// This script animates the puppies randomly and handles what happens if they are tossed off the island

	public AudioSource fallWhine, badJob;

	Vector3 startPosition;
	Quaternion startRotation;

	Animator anim;

	public SteamVR_LoadLevel resetLevel;

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
		// Have the dog whimper if it is tossed over the edge of the island
		if (transform.position.y < -1 && transform.position.y > -1.1)
		{
			fallWhine.Play();
		}

		// Prevent the dog from falling forever
		if (transform.position.y < -25)
		{
			badJob.Play();
			killDog();
		}
	}

	void killDog()
	{
		// Reset the level if the puppy is tossed off the island
		resetLevel.Trigger();
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

		Invoke("startAnimations", Random.Range(3.0f, 7.0f));

	}
}


