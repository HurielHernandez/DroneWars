using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

	public int number;
	public AudioSource checkpointSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{

		//print("CHeckpoint" + other.attachedRigidbody); 
		other.SendMessageUpwards("RegisterCheckpointHit", number, SendMessageOptions.RequireReceiver);
		other.SendMessageUpwards("RegisterCheckpointLocation", this.transform.position, SendMessageOptions.RequireReceiver);
		PlaySound();

	}

	public void PlaySound ()
	{
		checkpointSound.Play();
	}
}
