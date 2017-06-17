using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
	public AudioSource goodJob;
	public IntroManager introManager;

	Vector3 startPosition;
	Quaternion startRotation;

	// Use this for initialization
	void Start()
	{
		startPosition = transform.position;
		startRotation = transform.rotation;

	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y < -1 && transform.position.y > -1.1)
		{
			goodJob.Play();
		}

		if (transform.position.y < -25)
		{
			killPot();
		}
	}

	void killPot()
	{
		gameObject.SetActive(false);
		transform.position = startPosition;
		transform.rotation = startRotation;
		introManager.checkPots();
	}
}


