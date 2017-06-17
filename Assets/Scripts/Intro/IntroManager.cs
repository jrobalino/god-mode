using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

	// This script activates the exit portal if the player has thrown all the pots off the edge

	int potsThrown = 0;

	public AudioSource levelCleared;
	public GameObject exit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void checkPots()
	{
		potsThrown++;
		if (potsThrown == 3)
		{
			levelCleared.Play();
			exit.SetActive(true);
		}
	}
}
