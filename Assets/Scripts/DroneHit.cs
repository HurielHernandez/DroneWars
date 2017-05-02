using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHit : MonoBehaviour {

	public AudioSource droneHit;


	Rigidbody drone;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter ()  //Plays Sound Whenever collision detected
     {
         droneHit.Play ();
     }


}
