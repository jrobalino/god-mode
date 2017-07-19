using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HellfireManager : MonoBehaviour
{
	// This script checks the progress of the player on the first island of the Hellfire level 

	float damnedDogs = 0;
	float deadDogs = 0;
	public float dogsToDamn = 4f;
	public float dogCount = 7f;
	bool targetsRemainUnhit = true;
	public GameObject nextIsland;
	public AudioSource levelCleared, firstInstructions, secondInstructions, achievementClip;

	public GameObject achievement;
	public GameObject player;
	Text achievementText;
	bool achievement1 = false;

	public SteamVR_LoadLevel restartLevel;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void increaseDamned()
	{
		// Increases the number of targets hit and dead dogs by 0.5 (uses 0.5 because the dog collides twice with the target on account of having two components)
		damnedDogs = damnedDogs + 0.5f;
		deadDogs = deadDogs + 0.5f;
		checkConfiguration();
	}

	public void killDog()
	{
		// Increases the number of dead dogs
		deadDogs++;
		checkConfiguration();
	}


	void checkConfiguration()
	{
		if (damnedDogs == dogsToDamn) // All targets have been hit
		{
			if (deadDogs == damnedDogs)
			{
				unlockAchievement(0);
			}
			targetsRemainUnhit = false;
			levelCleared.Play();
			firstInstructions.Stop();
			secondInstructions.Play();
			nextIsland.SetActive(true);
		}
		if (((dogCount - deadDogs) < (dogsToDamn - damnedDogs)) && targetsRemainUnhit) // Reset level if there aren't enough dogs to hit the remaining targets
		{
			resetLevel();
		}
	}

	void resetLevel()
	{
		restartLevel.Trigger();
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
				if (!achievement1)
				{
					achievement1 = true;
					achievementText.text = "Sharpshooter";
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
