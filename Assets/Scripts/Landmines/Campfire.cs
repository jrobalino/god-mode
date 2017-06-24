using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour {

	// This script detects when the rich dog makes it safely to the exit
	public LandmineManager landmineManager;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Chocolate" || collision.collider.name == "Cupcake" || collision.collider.name == "Artic" || collision.collider.name == "Vanilla")
		{
			landmineManager.nextLevel();
			gameObject.GetComponent<Collider>().enabled = false;
		}	
	}
}
