using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private float speed = 1f;
	private float acceleration = 0.2f;
	private float maxspeed = 3.2f;

	private float easySpeed = 3.4f;
	private float mediumSpeed = 3.8f;
	private float hardSpeed = 4.3f;

	[HideInInspector]
	public bool moveCamera;

	// Use this for initialization
	void Start () {

		if (GamePreferences.GetEasyDifficultyState () == 1) {
			maxspeed = easySpeed;
		}		
		if (GamePreferences.GetMediumDifficultyState () == 1) {
			maxspeed = mediumSpeed;
		}		
		if (GamePreferences.GetHardDifficultyState () == 1) {
			maxspeed = hardSpeed;
		}		

		moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveCamera) {
			MoveCamera ();
		}
		
	}

	void MoveCamera() {
		Vector3 temp = transform.position;

		float oldY = temp.y;
		float newY = temp.y - (speed * Time.deltaTime);

		temp.y = Mathf.Clamp (temp.y, oldY, newY);

		transform.position = temp;

		speed += acceleration * Time.deltaTime;

		if (speed > maxspeed)
			speed = maxspeed;
	}
}
