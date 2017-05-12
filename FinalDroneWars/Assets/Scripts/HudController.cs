using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

	public Text altitudeText;
	public Text speedText;

	private GameObject drone;
	// Use this for initialization
	void Start () {
		altitudeText.text = "";
		speedText.text = "";

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		altitudeText.text = (Mathf.Round(this.GetComponentInParent<Rigidbody>().transform.position.y) + 25).ToString();
		float velX = Mathf.Round(Mathf.Abs(this.GetComponentInParent<Rigidbody>().velocity.x) * .10f);
		float velY = Mathf.Round(Mathf.Abs(this.GetComponentInParent<Rigidbody>().velocity.z) * .10f);
		speedText.text = (Mathf.Max(velX, velY)).ToString();

	
	}
}
