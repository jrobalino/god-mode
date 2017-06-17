using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource[] dogSounds;
	
	// Use this for initialization
	void Start () {
		Invoke("Bark", Random.Range(1.0f, 2.0f));
	}
	
	// Update is called once per frame
	void Update () {


	}

	void Bark()
	{
		int random = Random.Range(0, dogSounds.Length);
		dogSounds[random].Play();
		Invoke("Bark", Random.Range(0.5f, 4.0f));
	}
}
