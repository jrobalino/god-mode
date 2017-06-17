using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

	// This script checks whether the rich and poor dogs have been fed appropriately, and activates the exit portal if conditions are met

	int richBowls, poorBowls = 0;
	bool correctConfiguration = false;

	public int richBowlsNeeded = 4; // The target number of bowls to feed the rich dogs
	public int poorBowlsNeeded = 1; // The target number of bowls to feed the poor dogs

	public AudioSource goodJob;
	public AudioSource badJob;
	public AudioSource levelCleared;

	public GameObject exit;
	
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
}
