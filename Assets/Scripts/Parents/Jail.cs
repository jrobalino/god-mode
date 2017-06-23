using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour {

	public ParentManager parentManager;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		// Detect whether a parent is placed in jail
		if (collision.collider.name == "Dad1" || collision.collider.name == "Mom1" || collision.collider.name == "Dad2" || collision.collider.name == "Mom2" || collision.collider.name == "Dad3" || collision.collider.name == "Mom3")
		{
			parentManager.addToJail();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		// Detect whether a parent is removed in jail
		if (collision.collider.name == "Dad1" || collision.collider.name == "Mom1" || collision.collider.name == "Dad2" || collision.collider.name == "Mom2" || collision.collider.name == "Dad3" || collision.collider.name == "Mom3")
		{
			parentManager.removeFromJail();
		}
	}
}
