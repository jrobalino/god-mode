using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellfireManager : MonoBehaviour
{
	// This script checks the progress of the player through the Hellfire level 

	float damnedDogs = 0;
	float deadDogs = 0;
	public float dogsToDamn = 4f;
	public float dogCount = 7f;
	bool targetsRemainUnhit = true;

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
		}
		if (deadDogs == dogCount && targetsRemainUnhit) // Reset level if every dog has been killed or damned but targets remain unhit
		{
			resetLevel();
		}
	}

	void resetLevel()
	{
		restartLevel.Trigger();
	}
}
