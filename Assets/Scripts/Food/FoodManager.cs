using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

	int richBowls, poorBowls = 0;
	bool correctConfiguration = false;

	public int richBowlsNeeded = 4;
	public int poorBowlsNeeded = 1;

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
					levelCleared.Play();
					loadNextLevel();
				}
				else if (richBowls <= richBowlsNeeded)
				{
					goodJob.Play();
				}
				else badJob.Play();
				break;
			case 1: // When a bowl is taken away from the rich dogs table
				if (richBowls == richBowlsNeeded && poorBowls == poorBowlsNeeded)
				{
					levelCleared.Play();
					loadNextLevel();
				}
				break;
			case 2: // When a bowl is added to the poor dogs table
				if (richBowls == richBowlsNeeded && poorBowls == poorBowlsNeeded)
				{
					levelCleared.Play();
					loadNextLevel();
				}
				else if (poorBowls <= poorBowlsNeeded)
				{
					goodJob.Play();
				}
				else badJob.Play();
				break;
			case 3: // When a bowl is take away from the poor dogs table
				if (richBowls == richBowlsNeeded && poorBowls == poorBowlsNeeded)
				{
					levelCleared.Play();
					loadNextLevel();
				}
				break;
		}
		
	}

	public void feedTheRich()
	{
		richBowls++;
		checkConfiguration(0);
	}

	public void starveTheRich()
	{
		richBowls--;
		checkConfiguration(1);
	}

	public void feedThePoor()
	{
		poorBowls++;
		checkConfiguration(2);
	}

	public void starveThePoor()
	{
		poorBowls--;
		checkConfiguration(3);
	}

	void loadNextLevel()
	{
		exit.SetActive(true);
	}
}
