using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellTarget : MonoBehaviour
{
	public AudioSource goodJob;
	public Transform island;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * 9f);
		transform.RotateAround(island.position, transform.up, Time.deltaTime * 9f);
	}

	private void OnCollisionEnter(Collision collision)
	{

		// If a dog (tagged with CanDestroy) hits the mine, activate the explosion
		if (collision.collider.tag == "Shootable")
		{
			goodJob.Play();
			collision.gameObject.SetActive(false);
		}
	}
}
