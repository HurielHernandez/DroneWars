using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.name.Contains("Bullet")) {
			print("BULLET HIT");
		}
	}
}
