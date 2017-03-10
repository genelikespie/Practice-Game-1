﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f, maxVelocity = 4f;

	//viewable in inspector
	[SerializeField]
	private Rigidbody2D myBody;
	private Animator anim;

	void Awake() {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		PlayerMoveKeyboard ();
	}

	void PlayerMoveKeyboard() {
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		// -1 if you press left 0 for nothing and 1 for right
		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {
			if (vel < maxVelocity)
				forceX = speed;

			Vector3 temp = transform.localScale;
			temp.x = 1.3f;
			transform.localScale = temp;

			//idle to walk transition
			anim.SetBool ("Walk", true);
		} 
		else if (h < 0) 
		{
			if (vel < maxVelocity)
				forceX = -speed;

			Vector3 temp = transform.localScale;
			temp.x = -1.3f;
			transform.localScale = temp;

			//idle to walk transition
			anim.SetBool ("Walk", true);
		} 
		else 
		{
			anim.SetBool ("Walk", false);
		}

		myBody.AddForce(new Vector2(forceX, 0));
	}
}