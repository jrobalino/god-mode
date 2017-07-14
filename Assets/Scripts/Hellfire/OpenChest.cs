using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

	//This script resets the level if the player tosses the open chest off the island
	public AudioSource badJob;

	public SteamVR_LoadLevel resetLevel;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < -1 && transform.position.y > -1.1)
		{
			badJob.Play();
		}

		// Reset the level if the player throws the chest off the island
		if (transform.position.y < -25)
		{
			resetLevel.Trigger();
		}
	}
}
