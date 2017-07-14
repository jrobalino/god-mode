using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenGate : MonoBehaviour {

	// This script informs the portal which object passed through the heaven gate

	public HellPortal hellPortal;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Cupcake" || collision.gameObject.name == "Cupcake2" || collision.gameObject.name == "Cupcake3")
		{
			hellPortal.puppyHeaven();
			collision.gameObject.SetActive(false);
		}

		if (collision.gameObject.name == "Closed Chest")
		{
			hellPortal.closedChestHeaven();
			collision.gameObject.SetActive(false);
		}

		if (collision.gameObject.name == "Open Chest")
		{
			hellPortal.openChestHeaven();
			collision.gameObject.SetActive(false);
		}
	}
}
