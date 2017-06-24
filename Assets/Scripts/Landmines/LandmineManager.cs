using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineManager : MonoBehaviour {

	// This script moves the dogs in the landmine level and checks the player's progress through the level

	public GameObject[] dogs;
	GameObject dog;
	int i = 0;
	public float dogSpeed = 1.0f;
	public float smoothing = 100f;
	

	Animator anim;
	bool movingForward = false;
	Vector3 dogDirection;
	bool dogAlive = true;
	bool dogBlownUp = false;

	public GameObject player;
	public AudioSource dogReady;
	public AudioSource levelCleared;
	public GameObject exit;

	MineSweeper mineSweeper;

	public SteamVR_LoadLevel loadLevel, replayLevel;

	// Use this for initialization
	void Start()
	{
		initializeDog();
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

	void initializeDog()
	{
		// Get the active dog's animator
		dog = dogs[i];
		anim = dog.GetComponentInChildren<Animator>();
		mineSweeper = dog.GetComponent<MineSweeper>();
		mineSweeper.stopAnimating();
		dogAlive = true;
	} 

	public void nextLevel()
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
		dogBlownUp = true;
		movingForward = false;
		nextDog();
	}

	public void nextDog()
	{
		// Initialize the next dog available
		if (i < dogs.Length - 1)
		{
			i++;
			initializeDog();
			Invoke("spawnDogNearPlayer", 2.0f);
		}
		else restartLevel();
			
	}

	void spawnDogNearPlayer()
	{
		// spawn the next dog a little behind the player
		dog.transform.position = player.transform.position + new Vector3(0f, 0f, 1f);
		dogReady.Play();

	}

	void restartLevel() // Restarts the level
	{
		exit.SetActive(false);
		replayLevel.Trigger();
	}


}
