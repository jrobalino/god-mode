using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineManager : MonoBehaviour {

	// This script moves the dogs in the landmine level and checks the player's progress through the level

	public GameObject dog;
	public float dogSpeed = 1.0f;
	public float smoothing = 100f;
	

	Animator anim;
	bool movingForward = false;
	Vector3 dogDirection;
	bool dogAlive = true;

	public AudioSource levelCleared;
	public GameObject exit;

	// Use this for initialization
	void Start()
	{
		anim = dog.GetComponentInChildren<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (movingForward)
		{
			// Move the dog in the direction it's facing
			dog.transform.Translate(transform.forward * Time.deltaTime * dogSpeed);
		}
	}

	public void checkConfiguration()
	{
		levelCleared.Play();
		exit.SetActive(true);

	}

	// The movement functions are called by the ControllerInputManager script based on touchpad inputs

	public void moveDogForward()
	{
		if (dogAlive)
		{
			// Keep the dog facing forwards and start to run
			movingForward = true;
			anim.SetTrigger("Run");
		}
			
	}

	public void moveDogBackward()
	{
		if (dogAlive)
		{
			// Turn the dog backwards and start to run
			dogDirection = dog.transform.eulerAngles + 180f * transform.up;
			dog.transform.eulerAngles = dogDirection;
			movingForward = true;
			anim.SetTrigger("Run");
		}
			
	}

	public void moveDogLeft()
	{
		if (dogAlive)
		{
			// Turn the dog left and start to run
			dogDirection = dog.transform.eulerAngles - 90f * transform.up;
			dog.transform.eulerAngles = dogDirection;
			movingForward = true;
			anim.SetTrigger("Run");
		}
			
	}

	public void moveDogRight()
	{
		if (dogAlive)
		{
			// Turn the dog right and start to run
			dogDirection = dog.transform.eulerAngles + 90f * transform.up;
			dog.transform.eulerAngles = dogDirection;
			movingForward = true;
			anim.SetTrigger("Run");
		}
			
	}

	public void stopDog()
	{
		if (dogAlive)
		{
			// Make the dog idle and stop it from running forward
			anim.SetTrigger("Idle");
			movingForward = false;
		}
			
	}

	public void blowUpDog()
	{
		// Disable the dog's movement and controls if it has been blown up
		dogAlive = false;
		movingForward = false;
	}


}
