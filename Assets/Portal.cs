using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	float portalX, portalZ;

	public AudioSource portalSound;
	public GameObject player;
	public float distance = 1.0f;

	public SteamVR_LoadLevel loadLevel;

	// Use this for initialization
	void Start () {
		portalX = transform.position.x;
		portalZ = transform.position.z;
		checkPosition();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void checkPosition() {

		if ((Mathf.Abs(player.transform.position.x - portalX) < distance) && (Mathf.Abs(player.transform.position.z - portalZ) < distance))
		{
			portalSound.Play();
			loadLevel.Trigger();
		}
		else Invoke("checkPosition", 1.0f);
	}
	/**** Portals ****/

}
