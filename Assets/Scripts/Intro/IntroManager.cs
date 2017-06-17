using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

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
