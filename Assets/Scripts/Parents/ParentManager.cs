using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentManager : MonoBehaviour {

	// This script checks whether poor puppies have been isolated from their parents, and activates the exit portal if conditions are met

	int parentsCompromised = 0;
	bool correctConfiguration = false;

	public int parentsToCompromise = 3;

	public AudioSource goodJob;
	public AudioSource badJob;
	public AudioSource levelCleared;
	public AudioSource sadPuppy;
	public AudioSource achievementClip;

	public GameObject jail;
	public GameObject exit;

	public SteamVR_LoadLevel loadLevel;

	public GameObject achievement;
	public GameObject player;
	Text achievementText;
	bool achievement1 = false;

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
			case 0: // When a parent is added to jail
				if (parentsCompromised == parentsToCompromise)
				{
					// Load the next level if the right number of parents have been compromised
					levelCleared.Play();
					loadNextLevel();
				}
				else if (parentsCompromised < parentsToCompromise)
				{
					// Play an affirming sound if the player correctly compromised another parent
					goodJob.Play();
				}
				else
				{
					// Play a negative sound if player puts too many parents in jail and deactivate the portal
					badJob.Play();
					disableNextLevel();
				}
				break;
			case 1: // When a parent is removed from jail
				if (parentsCompromised == parentsToCompromise)
				{
					// Load the next level if the right number of parents have been compromised
					levelCleared.Play();
					loadNextLevel();
				}
				else if (parentsCompromised < parentsToCompromise)
				{
					// Play a negative sound if the player shouldn't have removed the parent from jail
					badJob.Play();
				}
				break;
			case 2: // When a parent is thrown over the edge
				if (parentsCompromised == parentsToCompromise)
				{
					// Load the next level if the right number of parents have been compromised
					levelCleared.Play();
					loadNextLevel();
				}
				else if (parentsCompromised < parentsToCompromise)
				{
					// Play an affirming sound if the player correctly compromised another parent
					goodJob.Play();
				}
				else
				{
					// Play a negative sound if player threw too many dogs over the edge and reload level
					badJob.Play();
					restartLevel();
				}
				break;
		}
		
	}

	public void addToJail() // Runs when a parent is added to jail
	{
		parentsCompromised++;
		sadPuppy.Play();
		checkConfiguration(0);
	}

	public void removeFromJail() // Runs when a parent is removed from jail
	{
		parentsCompromised--;
		checkConfiguration(1);
	}

	public void throwOverboard() // Runs when a parent is thrown overboard
	{
		parentsCompromised++;
		sadPuppy.Play();
		checkConfiguration(2);
	}

	void loadNextLevel() // Activates the exit portal
	{
		exit.SetActive(true);
	}

	void disableNextLevel() // Deactivates the exit portal
	{
		exit.SetActive(false);
	}

	void restartLevel() // Restarts the level
	{
		exit.SetActive(false);
		loadLevel.Trigger();
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
					achievementText.text = "Adoption";
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
