using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellfireManager : MonoBehaviour
{
	// This script checks the progress of the player on the first island of the Hellfire level 

	float damnedDogs = 0;
	float deadDogs = 0;
	public float dogsToDamn = 4f;
	public float dogCount = 7f;
	bool targetsRemainUnhit = true;
	public GameObject nextIsland;
	public AudioSource levelCleared, firstInstructions, secondInstructions;

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
}
