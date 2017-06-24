using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	Transform explosion; // Explosion prefab
	MineSweeper mineSweeper; // The dog

	// Use this for initialization
	void Start () {
		explosion = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{

		// If a dog (tagged with CanDestroy) hits the mine, activate the explosion
		if (collision.collider.tag == "CanDestroy")
		{
			explosion.gameObject.SetActive(true);
			mineSweeper = collision.gameObject.GetComponent<MineSweeper>();
			mineSweeper.blowUpDog();
		}
	}
}
