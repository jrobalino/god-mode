using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

	// This script controls whether the chest is open or closed based on whether the player casts the puppies into hell

	public GameObject openChest;
	public AudioSource badJob, levelCleared;
	public int puppyCount = 3;
	public HellPortal hellPortal;
	int forsakenPuppies = 0;

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

	public void unlockChest()
	{
		// When a puppy is cast to hell, this function runs. If all puppies have been forsaken, it opens the chest

		forsakenPuppies++;
		if (forsakenPuppies == puppyCount)
		{
			levelCleared.Play();
			hellPortal.explainChest();
			openChest.SetActive(true);
			gameObject.SetActive(false);
		}
	}


}
