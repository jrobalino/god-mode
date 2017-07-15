using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HellPortal : MonoBehaviour
{
	// This script controls what happens when the player casts an object through the heaven or hell portal
	public Chest chest;
	public AudioSource goodJob, badJob, levelCleared;

	public SteamVR_LoadLevel resetLevel;
	//public SteamVR_LoadLevel statusQuoTrue;
	public SteamVR_LoadLevel statusQuoFalse;

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
		// Nothing happens -- the player can send the puppies to heaven before deciding what to do about the chest
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

}
