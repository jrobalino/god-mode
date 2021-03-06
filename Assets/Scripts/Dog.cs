﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
	// This script animates the dogs randomly and handles how they behave if they are tossed off the island

	public AudioSource fallWhine;
	public bool isParent, isPuppy = false;
	public ParentManager parentManager;

	Vector3 startPosition;
	Quaternion startRotation;

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
		if(transform.position.y > 7.3f && isPuppy)
		{
			parentManager.unlockAchievement(0);
		}
		
		// Have the dog whimper if it is tossed over the edge of the island
		if (transform.position.y < -1 && transform.position.y > -1.1)
		{
			fallWhine.Play();
		}

		// Prevent the dog from falling forever
		if (transform.position.y < -25)
		{
			killDog();
		}
	}

	void killDog()
	{
		// Return the dog to its starting position but make it inactive
		gameObject.SetActive(false);
		transform.position = startPosition;
		transform.rotation = startRotation;
		if (isParent)
		{
			parentManager.throwOverboard();
		}
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


