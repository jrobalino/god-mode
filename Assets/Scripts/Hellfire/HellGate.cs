using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellGate : MonoBehaviour {

	// This script informs the portal what object passed through the hell gate

	public HellPortal hellPortal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Cupcake" || collision.gameObject.name == "Cupcake2" || collision.gameObject.name == "Cupcake3")
		{
			hellPortal.puppyHell();
			collision.gameObject.SetActive(false);
		}

		if (collision.gameObject.name == "Closed Chest")
		{
			hellPortal.closedChestHell();
			collision.gameObject.SetActive(false);
		}

		if (collision.gameObject.name == "Open Chest")
		{
			hellPortal.openChestHell();
			collision.gameObject.SetActive(false);
		}
	}
}
