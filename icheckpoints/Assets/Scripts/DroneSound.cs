using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DroneSound : NetworkBehaviour {

	public AudioSource droneSound;


	Rigidbody drone;
	// Use this for initialization
	void Start () {
		if(isLocalPlayer)
			droneSound.Play();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isLocalPlayer) {
			float pitch = -Input.GetAxis ("Vertical");
			//print("Pitch" + pitch);

			if (pitch < .05f)
				pitch = 0f;

			this.droneSound.pitch = pitch;
		}
	}
}
