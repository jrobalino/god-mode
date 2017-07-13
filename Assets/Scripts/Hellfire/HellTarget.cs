using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellTarget : MonoBehaviour
{
	// This script controls how the targets behave in the Hellfire level

	public AudioSource goodJob;
	public Transform island;
	public HellfireManager hellfireManager;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// Rotate the targets around the starting island and around the y axis
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * 9f);
		transform.RotateAround(island.position, transform.up, Time.deltaTime * 9f);
	}

	private void OnCollisionEnter(Collision collision)
	{

		// If a dog (tagged with Shootable) hits the target, deactivate the target and increase the number of dogs cast to hell by calling the HellfireManager script
		if (collision.collider.tag == "Shootable")
		{
			goodJob.Play();
			hellfireManager.increaseDamned();
			collision.gameObject.SetActive(false);
			gameObject.SetActive(false);
		}
	}
}
