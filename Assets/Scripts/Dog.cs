using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
	public AudioSource fallWhine;

	Vector3 startPosition;
	Quaternion startRotation;

	Animator anim;

	// Use this for initialization
	void Start()
	{
		startPosition = transform.position;
		startRotation = transform.rotation;
		anim = GetComponentInChildren<Animator>();
		startAnimations();

	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y < -1 && transform.position.y > -1.1)
		{
			fallWhine.Play();
		}

		if (transform.position.y < -25)
		{
			killDog();
		}
	}

	void killDog()
	{
		gameObject.SetActive(false);
		transform.position = startPosition;
		transform.rotation = startRotation;
	}

	void startAnimations()
	{
		int random = Random.Range(0, 3);

		switch (random)
		{

			case 0:
				anim.SetTrigger("Idle");
				break;

			case 1:
				anim.SetTrigger("Bark");
				break;

			case 2:
				anim.SetTrigger("Jump");
				break;
		}

		Invoke("startAnimations", Random.Range(3.0f, 7.0f));

	}
}


