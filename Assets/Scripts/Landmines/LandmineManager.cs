using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public AudioSource achievementClip;
	public GameObject exit;

	MineSweeper mineSweeper;

	public GameObject achievement;
	public GameObject playerHead;
	Text achievementText;
	bool achievement1 = false;

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
		if(i == 0)
		{
			unlockAchievement(0);
		}
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

	public void unlockAchievement(int scenario) // Displays achievements as they are unlocked
	{
		achievementText = achievement.GetComponentsInChildren<Text>()[1]; // the text to overwrite depending on what achievement was unlocked
		achievement.transform.position = playerHead.transform.position + playerHead.transform.forward * 3f; // spawn the achievement in front of the player
		achievement.transform.position = new Vector3(achievement.transform.position.x, playerHead.transform.position.y, achievement.transform.position.z); // raise the achievement to player height
		achievement.transform.rotation = Quaternion.LookRotation(playerHead.transform.forward); // align the achievement in the direction the player is looking
		switch (scenario)
		{
			case 0:
				if (!achievement1)
				{
					achievement1 = true;
					achievementText.text = "Minesweeper";
					achievementClip.Play();
					achievement.SetActive(true);
					Invoke("hideAchievement", 3.0f);
				}
				break;
		}
	}

	void hideAchievement()
	{
		achievement.SetActive(false);
	}


}
