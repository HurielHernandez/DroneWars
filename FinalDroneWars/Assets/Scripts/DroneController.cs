﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DroneController : MonoBehaviour {


	Rigidbody body;
    Transform mTransform;
	Vector3 frontLeft, frontRight, rearLeft, rearRight;
	public Camera firstPerson;
	public Camera thirdPerson;
	public Text modeText;
	public Text checkpointNumberText ;
	public Text timerText;
	public Text completedText;

	int lastCheckPointCrossed = 0;
	public float timer;

	const float MAX_FORCE = 50;
    float MAX_TILT = 70f;
    const float STEER_FORCE = 50f;
    const float MAX_SPIN = 50f;

    Vector3 resetLocation = Vector3.zero;
  

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
       	mTransform = GetComponent<Transform>();
        frontLeft = new Vector3(-mTransform.localScale.x, 0, mTransform.localScale.x);
        frontRight = new Vector3(mTransform.localScale.x, 0, mTransform.localScale.x);
        rearLeft = new Vector3(-mTransform.localScale.x, 0, -mTransform.localScale.x);
        rearRight = new Vector3(mTransform.localScale.x, 0, -mTransform.localScale.x);
		mTransform.Rotate(new Vector3(0, -90, 0 ));   
		toggleCamera();
		GameObject.Find("Title").SetActive(false);
	}

	void Update ()
	{
		
		//mac
// 		if (Input.GetKeyDown (KeyCode.JoystickButton19)) {
// 			toggleCamera ();
// 		}
// 		if (Input.GetKeyDown (KeyCode.Joystick1Button10)) {
// 			mTransform.position = resetLocation;
// 			mTransform.eulerAngles = new Vector3 (0, 0, 0);

// //			mTransform.Rotate(new Vector3(0, -90, 0 ));
// 		}

// 		if (Input.GetKeyUp (KeyCode.Joystick1Button18)) {
// 			if (MAX_TILT == 360f) {
// 				MAX_TILT = 70f;
// 				modeText.text = "EASY";
		
// 			} else {
// 				MAX_TILT = 360f;
// 				modeText.text = "ADVANCED";
			
// 			}
// 		}

// 		if (Input.GetKeyDown (KeyCode.JoystickButton9)) {
// 			resetCheckpoints ();
// 		}

		//windows
		if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
			toggleCamera ();
		}
		if (Input.GetKeyDown(KeyCode.Joystick1Button6)) {
			mTransform.position = Vector3.zero;
			mTransform.eulerAngles = new Vector3 (0, 0 , 0);
		}

		if (Input.GetKeyUp(KeyCode.Joystick1Button2)) {
			if(MAX_TILT == 360f)
			{
				MAX_TILT = 75f;
				modeText.text = "EASY";
			}
			else
			{
				MAX_TILT = 360f;
				modeText.text = "ADVANCED";
			}
		}

			if (Input.GetKeyDown (KeyCode.JoystickButton7)) {
			resetCheckpoints ();
		}

	}


	// Update is called once per frame
	void FixedUpdate ()
	{
		
		float pitch = Input.GetAxis ("RightJoystickVertical");
		float roll = Input.GetAxis ("RightJoystickHorizontal");
		float throttle = Input.GetAxis ("Vertical");
		float yaw = Input.GetAxis ("Horizontal") * .01f;


//        print( pitch + " " + roll + " " + throttle + " " + yaw);

		Vector3 orientation = mTransform.localRotation.eulerAngles;
		orientation.y = 0;
		FixRanges(ref orientation);

		Vector3 localangularvelocity = mTransform.InverseTransformDirection(body.angularVelocity);
		float velY = body.velocity.y;

		float desiredPitch = -pitch * MAX_TILT - (orientation.x + localangularvelocity.x * 15);
		float desiredRoll = -roll * MAX_TILT - ( orientation.z + localangularvelocity.z * 15);

		ApplyForces( desiredPitch / MAX_TILT, desiredRoll / MAX_TILT,   -throttle, yaw );

		if (lastCheckPointCrossed > 0 && lastCheckPointCrossed < 20) {
			timer += Time.deltaTime;
			timerText.text =  Mathf.Round(timer) + " sec" ;
		}
 
	}

	void ApplyForces (float pitch, float roll, float throttle , float yaw)
	{

		float totalY =  Mathf.Min( throttle * 1800f, 4000f) ;

		if( totalY < 0)
			totalY = 0;
			        
//		print("throttle" + totalY);

		Vector3 frontLeftForce = mTransform.up * (   - pitch * STEER_FORCE - roll * STEER_FORCE );
		Vector3 frontRightForce = mTransform.up * (  - pitch * STEER_FORCE + roll * STEER_FORCE );
		Vector3 backLeftForce = mTransform.up * (   + pitch * STEER_FORCE - roll * STEER_FORCE );
		Vector3 backRightForce = mTransform.up * (  + pitch * STEER_FORCE + roll * STEER_FORCE );

		//Up
		body.AddRelativeForce( 0, totalY , 0);
		//Left
		body.AddRelativeForce(roll * -1,0,0);

//		print("FOrces" + frontLeftForce + " " + frontRightForce + " " + backLeftForce + " " + backRightForce);

		//front left
		body.AddForceAtPosition( frontLeftForce  , mTransform.position + mTransform.TransformDirection(frontLeft));

		//front right
		body.AddForceAtPosition( frontRightForce , mTransform.position + mTransform.TransformDirection(frontRight ));

		//rear left
		body.AddForceAtPosition( backLeftForce , mTransform.position + mTransform.TransformDirection(rearLeft ));
 
        //rear right
		body.AddForceAtPosition( backRightForce ,  mTransform.position + mTransform.TransformDirection(rearRight));	

//		print(mTransform.eulerAngles + "Angles" );

		//Front
        body.AddForceAtPosition( mTransform.right * yaw * 8000f, mTransform.position + mTransform.forward );
        //Rear
        body.AddForceAtPosition( -mTransform.right * yaw * 8000f, mTransform.position - mTransform.forward );

       
	}

	void FixRanges( ref Vector3 euler )
        {
                if (euler.x < -180)
                        euler.x += 360;
                else if (euler.x > 180)
                        euler.x -= 360;
 
                if (euler.y < -180)
                        euler.y += 360;
                else if (euler.y > 180)
                        euler.y -= 360;
 
                if (euler.z < -180)
                        euler.z += 360;
                else if (euler.z > 180)
                        euler.z -= 360;
        }

   void toggleCamera ()
	{
		if(firstPerson.enabled) {
            firstPerson.enabled = false;
            firstPerson.gameObject.SetActive(false);
            thirdPerson.gameObject.SetActive(true);
            thirdPerson.enabled = true;
        } else {
            thirdPerson.enabled = false;
            thirdPerson.gameObject.SetActive(false);
            firstPerson.gameObject.SetActive(true);
            firstPerson.enabled = true;
        }
	}

	public void enableScript(){
	}


	void OnCollisionEnter (Collision collision)
	{
		//print ("Collision" + collision.relativeVelocity + " " + collision.gameObject.name);

		if (collision.gameObject.name.StartsWith("Bullet"))
			gameObject.transform.position = Vector3.zero;

	

	}


	public void RegisterCheckpointHit (int number)
	{
		//print("CHECKPOINT" + number + " CROSSED");
		if (number - 1 == lastCheckPointCrossed) {
			lastCheckPointCrossed++;
			GetComponentInParent<CheckpointManager> ().ShowNextCheckpoint (lastCheckPointCrossed);
		}
	
		checkpointNumberText.text = lastCheckPointCrossed + " of 20";

		if (number == 20) {
			completedText.text = "COMPLETED! \n" + Mathf.Round(timer) + " seconds";
			//lastCheckPointCrossed = 1;
			//timer = 0;
		}
	}

	public void RegisterCheckpointLocation (Vector3 checkpointLocation)
	{
		//print("LOCATION" + checkpointLocation);

		resetLocation = checkpointLocation;
	}

	void resetCheckpoints ()
	{
		lastCheckPointCrossed = 0;
		GetComponentInParent<CheckpointManager> ().ShowNextCheckpoint (lastCheckPointCrossed);
		checkpointNumberText.text = lastCheckPointCrossed + " of 20";
		completedText.text = "";
		timer = 0;
		resetLocation = Vector3.zero;
		mTransform.position = resetLocation;
		mTransform.Rotate(new Vector3(0, -90, 0));
		timerText.text = "0:00";
	}


}
