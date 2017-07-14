﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {
	public float upwardForceToApply = 100.0f;
	public float maxSpeedY = 10.0f;
	Vector2 worldVelocity = Vector2.right*2.5f;

	public Vector3 initialPosition = new Vector3 ();
	public Quaternion initialRotation = new Quaternion();
	public float initialAngularVelocity = 0.0f;
	public GameObject planeRed;
	public GameObject planeGreen;
	public GameObject activePlane;

	public GameManager manager;
	public ObstacleController obstacles;
	public UIController uiController;

	void Start() {
		//		getRigidBody2d ().centerOfMass = new Vector2 (-1, 0.4f);
		//		getRigidBody2d ().angularVelocity = 10.0f;
		initialPosition = gameObject.transform.position;
		initialRotation = gameObject.transform.rotation;
		UnityEngine.Rigidbody2D rb = getRigidBody2d ();
		initialAngularVelocity = rb.angularVelocity;
	}

	public GameObject getActivePlane() {
		return activePlane;
	}

	public UnityEngine.Rigidbody2D getRigidBody2d() {
		return gameObject.GetComponent<Rigidbody2D> ();
	}

	public void resetToMenuState() {
		gameObject.transform.SetPositionAndRotation (initialPosition, initialRotation);
		getRigidBody2d ().Sleep ();
		activePlane.GetComponent<Animator> ().speed = 0;
		uiController.resetScore();
	}

	public void resetPlaneInIngame() {
		UnityEngine.Rigidbody2D rb = getRigidBody2d ();
		activePlane.GetComponent<Animator> ().speed = 1;
		rb.WakeUp ();
		gameObject.transform.SetPositionAndRotation (initialPosition, initialRotation);
		rb.angularVelocity = initialAngularVelocity;
		rb.velocity = Vector2.zero;


	}
	void FixedUpdate(){
		if (manager.gameState == GameManager.GAMESTATE.kIngame) {
			UnityEngine.Rigidbody2D rb = getRigidBody2d ();
			Vector2 direction = rb.velocity;
			direction += worldVelocity;
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			rb.MoveRotation (angle);

			if (Mathf.Abs (rb.velocity.y) >= maxSpeedY) {
				rb.velocity = new Vector2 (rb.velocity.x, Mathf.Sign (rb.velocity.y) * maxSpeedY);
			} 
		}
	}
	public void throttleUp() {
		UnityEngine.Rigidbody2D rb = getRigidBody2d ();
		rb.AddForce (Vector2.up * upwardForceToApply);
	}

	public void switchPlane() {
		if (activePlane == planeRed) {
			activePlane.SetActive (false);
			activePlane = planeGreen;
			activePlane.SetActive (true);
		} else {
			activePlane.SetActive (false);
			activePlane = planeRed;
			activePlane.SetActive (true);
		}
		resetToMenuState ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (LayerMask.LayerToName (collision.gameObject.layer) == "Borders") {
			resetPlaneInIngame ();
			obstacles.resetObstaclesInIngame ();
			uiController.resetScore ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (LayerMask.LayerToName (other.gameObject.layer) == "Borders") {
			resetPlaneInIngame ();
			obstacles.resetObstaclesInIngame ();
			uiController.resetScore ();
		}
		if (other.tag == "Obstacles") {
			uiController.addScore ();

		}
	}
}