using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShootingController : NetworkBehaviour {

	public GameObject bullet;
	public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("RightTrigger" ) > 0 && isLocalPlayer)
			CmdFire();
	}


	void CmdFire ()
	{
		GameObject newBullet = (GameObject) Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
		newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * 900.0f;
		newBullet.transform.eulerAngles = newBullet.transform.eulerAngles + new Vector3(90f, 90f, 90f);
		//print(newBullet.transform.eulerAngles);
		//NetworkServer.Spawn(newBullet);
		Destroy(newBullet, 3);
	}
}
