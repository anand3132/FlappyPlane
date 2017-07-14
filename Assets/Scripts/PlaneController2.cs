using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController2 : MonoBehaviour {
	public float upwardForceToApply = 100f;
	public float maxSpeedY = 5.0f;
	Vector2 worldVelocity = Vector2.right*.5f;

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
		Physics2D.gravity = new Vector2 (0.0f, 0.0f);
		getRigidBody2d ().centerOfMass = new Vector2 (-1, 0.4f);
		getRigidBody2d ().angularVelocity = 10.0f;
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
		gameObject.transform.position = initialPosition;
		gameObject.transform.rotation = initialRotation;
		getRigidBody2d ().Sleep ();
		activePlane.GetComponent<Animator> ().speed = 0;
	}

	public void resetPlaneInIngame() {
		activePlane.GetComponent<Animator> ().speed = 1;
		getRigidBody2d ().WakeUp ();
		gameObject.transform.SetPositionAndRotation (initialPosition, initialRotation);
		UnityEngine.Rigidbody2D rb = getRigidBody2d ();
		rb.angularVelocity = initialAngularVelocity;
		rb.velocity = Vector2.zero;
	}

	public void throttleUp() {
		UnityEngine.Rigidbody2D rb = getRigidBody2d ();
		rb.AddForce (Vector2.up * 50f);

//		var dir = rb.velocity;
//		dir += worldVelocity;
//
//		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//		var diffAngle = angle - (rb.rotation + 90);		
//		rb.MoveRotation(angle);
//
//		if (Mathf.Abs(rb.velocity.y) >= maxSpeedY){
//			rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * maxSpeedY);
//		}     


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
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (LayerMask.LayerToName (other.gameObject.layer) == "Borders") {
			resetPlaneInIngame ();
			obstacles.resetObstaclesInIngame ();
		}
		if (other.tag == "Obstacles") {
			uiController.addScore();
			Debug.Log ("Plane crossed border "+uiController.score);

		}
	}

	public void printInfo() {
		Debug.Log ("center of Mass : " + getRigidBody2d ().centerOfMass.ToString ());
		Debug.Log ("angular velocity : " + getRigidBody2d ().angularVelocity.ToString ());
	}
}
