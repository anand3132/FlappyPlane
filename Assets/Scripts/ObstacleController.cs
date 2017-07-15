using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to controll the obstacle movement and generation of our game.
// Created By Anand.A

public class ObstacleController : MonoBehaviour {
	public GameManager manager;
	public GameObject obstacle;
	public Vector3 randomPosition = new Vector3 ();
	float speed = 3.0f;

	public void switchToMenu() {
		obstacle.SetActive (false);
	}

	public void switchToInGame() {
		obstacle.SetActive (true);
	}

	void Update () {
		if (manager.gameState == GameManager.GAMESTATE.kIngame) {
			UpdateObstacles ();
		}
	}

	void UpdateObstacles() {
		if (gameObject.transform.position.x > -3.0f) {
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		} else {
			resetObstaclesInIngame ();
		}
	}

	public void resetObstaclesInIngame() {
		randomPosition.y = Random.Range (-2f, 2f);
		randomPosition.x = Random.Range (3f, 6f);
		gameObject.transform.position = randomPosition;
	}

}
