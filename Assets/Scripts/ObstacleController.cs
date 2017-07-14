using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
	public GameManager manager;
	public GameObject obstacle;
	public Vector3 initialPosition = new Vector3 ();
	int speed =4;
	// Use this for initialization
	void Start () {
		initialPosition = gameObject.transform.position;
	}

	void Update () {
		if (manager.gameState == GameManager.GAMESTATE.kIngame) {
			StartScroll ();
		}
	}
	void StartScroll(){
		//int randomNumber = (int)Random.Range (0f, 100.0f);
		if (gameObject.transform.position.x > -3)
			this.transform.Translate (Vector3.left * Time.deltaTime * speed);
		else {
			gameObject.transform.position = initialPosition;
		}

	}
	public void resetObstaclesInIngame(){
		gameObject.transform.position = initialPosition;
	}

}
