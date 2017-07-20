using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HellPortal : MonoBehaviour
{
	// This script controls what happens when the player casts an object through the heaven or hell portal
	public Chest chest;
	public AudioSource goodJob, badJob, levelCleared, secondInstructions, treasureInstructions, puppySaved, puppySaved2, puppySaved3, achievementClip;

	public SteamVR_LoadLevel resetLevel;
	//public SteamVR_LoadLevel statusQuoTrue;
	public SteamVR_LoadLevel statusQuoFalse;

	public GameObject achievement;
	public GameObject player;
	Text achievementText;
	bool achievement1 = false;

	int puppiesInHeaven = 0;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// Rotate the heaven and hell portal around the y axis
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * 9f);
	}

	public void puppyHell() // Cast a puppy to hell
	{
		goodJob.Play();
		chest.unlockChest(); // Call script to check whether all puppies have been cast to hell, and if so, unlock the chest
	}

	public void puppyHeaven()
	{
		// If the player tosses a puppy into heaven instead of hell, provide relevant commentary
		puppiesInHeaven++;
		switch (puppiesInHeaven)
		{
			case 1:
				secondInstructions.Stop();
				puppySaved.Play();
				break;
			case 2:
				puppySaved.Stop();
				puppySaved2.Play();
				break;
			case 3:
				puppySaved2.Stop();
				unlockAchievement(0);
				puppySaved3.Play();
				break;
		}
	}

	public void closedChestHeaven() // The player fails if they send the chest to the rich dogs without opening it
	{
		badJob.Play();
		resetLevel.Trigger();
	}

	public void closedChestHell() // The player completes the game while upsetting the status quo if they send the closed chest to hell
	{
		levelCleared.Play();
		statusQuoFalse.Trigger();
	}

	public void openChestHeaven() // The player completes the game while maintaining the status quo if they send the opened chest to heaven
	{
		levelCleared.Play();
		SceneManager.LoadScene("StatusQuoTrue"); // Using SceneManager for this instance due to SteamVR bug
	}

	public void openChestHell() // The player completes the game while upsetting the status quo if they send the opened chest to hell
	{
		levelCleared.Play();
		statusQuoFalse.Trigger();
	}

	public void explainChest() // Explain what to do with the open treasure chest
	{
		secondInstructions.Stop();
		treasureInstructions.Play();
	}

	public void unlockAchievement(int scenario) // Displays achievements as they are unlocked
	{
		achievementText = achievement.GetComponentsInChildren<Text>()[1]; // the text to overwrite depending on what achievement was unlocked
		achievement.transform.position = player.transform.position - player.transform.forward * 3f; // spawn the achievement behind the player (so it's not in the portal)
		achievement.transform.position = new Vector3(achievement.transform.position.x, player.transform.position.y, achievement.transform.position.z); // raise the achievement to player height
		achievement.transform.rotation = Quaternion.LookRotation(-player.transform.forward); // align the achievement in the direction the player is looking
		switch (scenario)
		{
			case 0:
				if (!achievement1)
				{
					achievement1 = true;
					achievementText.text = "Favorite Uncle";
					achievementClip.Play();
					achievement.SetActive(true);
					Invoke("hideAchievement", 10.0f);
				}
				break;
		}
	}

	void hideAchievement()
	{
		achievement.SetActive(false);
	}

}
