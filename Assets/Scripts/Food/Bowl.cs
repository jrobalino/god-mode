using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour {

	Vector3 startPosition;
	Quaternion startRotation;

	public FoodManager foodManager;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -25)
		{
			transform.position = startPosition;
			transform.rotation = startRotation;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.collider.name == "RichTable")
		{
			foodManager.feedTheRich();
		}

		if (collision.collider.name == "PoorTable")
		{
			foodManager.feedThePoor();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.name == "RichTable")
		{
			foodManager.starveTheRich();
		}

		if (collision.collider.name == "PoorTable")
		{
			foodManager.starveThePoor();
		}
	}
}
