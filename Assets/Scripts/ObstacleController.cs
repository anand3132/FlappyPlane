using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
	public GameManager manager;
	public GameObject obstacle;
	public Vector3 initialPosition = new Vector3 ();
	public Vector3 randomPosition = new Vector3 ();

	int speed =3;
	float randomNumber;

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
		if (gameObject.transform.position.x > -3) {
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
		else {
			resetObstaclesInIngame ();
		}
	}
	public void resetObstaclesInIngame(){
		randomNumber = Random.Range (-1f, 1f);
		randomPosition.y = randomNumber ;
		gameObject.transform.position =initialPosition+randomPosition;
	}

}
