using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour {

	// This script checks whether the rich and poor dogs have been fed appropriately, and activates the exit portal if conditions are met

	int richBowls, poorBowls = 0;
	bool correctConfiguration = false;

	public int richBowlsNeeded = 4; // The target number of bowls to feed the rich dogs
	public int poorBowlsNeeded = 1; // The target number of bowls to feed the poor dogs

	public AudioSource goodJob, badJob, levelCleared, achievementClip;


	public GameObject exit;
	public GameObject achievement;
	public GameObject player;
	Text achievementText;
	bool achievement1, achievement2 = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void checkConfiguration(int action)
	{
		switch (action)
		{
			case 0: // When a bowl is added to the rich dogs table
				if (richBowls == richBowlsNeeded && poorBowls == poorBowlsNeeded)
				{
					// Load the next level if all dogs have been fed properly
					levelCleared.Play();
					loadNextLevel();
				}
				else if (richBowls <= richBowlsNeeded)
				{
					// Play an affirming sound if the player fed rich dogs in need
					goodJob.Play();
				}
				else badJob.Play(); // Play a negative sound if player overfed the rich dogs
				break;
			case 1: // When a bowl is taken away from the rich dogs table
				if (richBowls == richBowlsNeeded && poorBowls == poorBowlsNeeded)
				{
					// Load the next level if all dogs have been fed properly
					levelCleared.Play();
					loadNextLevel();
				}
				break;
			case 2: // When a bowl is added to the poor dogs table
				if (richBowls == richBowlsNeeded && poorBowls == poorBowlsNeeded)
				{
					// Load the next level if all dogs have been fed properly
					levelCleared.Play();
					loadNextLevel();
				}
				else if (poorBowls <= poorBowlsNeeded)
				{
					// Play an affirming sound if the player fed poor dogs in need
					goodJob.Play();
				}
				else badJob.Play(); // Play a negative sound if the player overfed the poor dogs
				break;
			case 3: // When a bowl is take away from the poor dogs table
				if (richBowls == richBowlsNeeded && poorBowls == poorBowlsNeeded)
				{
					// Load the next level if all dogs have been fed properly
					levelCleared.Play();
					loadNextLevel();
				}
				break;
		}
		
	}

	public void feedTheRich() // Runs when a bowl is added to the rich table
	{
		richBowls++;
		checkConfiguration(0);
	}

	public void starveTheRich() // Runs when a bowl is removed from the rich table
	{
		richBowls--;
		checkConfiguration(1);
	}

	public void feedThePoor() // Runs when a bowl is added to the poor table
	{
		poorBowls++;
		checkConfiguration(2);
	}

	public void starveThePoor() // Runs when a bowl is removed from the poor table
	{
		poorBowls--;
		checkConfiguration(3);
	}

	void loadNextLevel() // Activates the exit portal
	{
		exit.SetActive(true);
	}

	public void unlockAchievement(int scenario) // Displays achievements as they are unlocked
	{
		achievementText = achievement.GetComponentsInChildren<Text>()[1]; // the text to overwrite depending on what achievement was unlocked
		achievement.transform.position = player.transform.position + player.transform.forward * 3f; // spawn the achievement in front of the player
		achievement.transform.position = new Vector3(achievement.transform.position.x, player.transform.position.y, achievement.transform.position.z); // raise the achievement to player height
		achievement.transform.rotation = Quaternion.LookRotation(player.transform.forward); // align the achievement in the direction the player is looking
		switch (scenario)
		{
			case 0:
				if(!achievement1)
				{
					achievement1 = true;
					achievementText.text = "Gluttony";
					achievementClip.Play();
					achievement.SetActive(true);
					Invoke("hideAchievement", 3.0f);
				}
				break;
			case 1:
				if (!achievement2)
				{
					achievement2 = true;
					achievementText.text = "Top Chef";
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
