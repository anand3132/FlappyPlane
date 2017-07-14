using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {

	// gui components
	public Text scoreText;
	public Text bestScoreText;
	public Text tapText;
	public GameObject tap;
	public Button flappyBanner;
	public Button switchPlaneButton;
	public Button menuButton;

	public GameManager manager;

	// scoring systems
	public int score=0;
	int bestScore = 0;

	void Start () {
		//PlayerPrefs.SetInt ("bestScore", 0);
		score = 0;
		bestScore = PlayerPrefs.GetInt ("bestScore");;
	}

	public void switchToMenu() {
		scoreText.text = "";
		bestScoreText.text = "";
		tapText.text = "Tap to Play";
		menuButton.gameObject.SetActive(false);
		switchPlaneButton.gameObject.SetActive(true);
		flappyBanner.gameObject.SetActive(true);
		tap.gameObject.SetActive (true);
	}

	public void switchToIngame() {
		tapText.text = "";
		menuButton.gameObject.SetActive(true);
		switchPlaneButton.gameObject.SetActive(false);
		flappyBanner.gameObject.SetActive(false);
		tap.gameObject.SetActive (false);
	}
	void Update(){
		if (manager.gameState == GameManager.GAMESTATE.kIngame) {
			scoreText.text = "Score: " + score.ToString ();
			bestScoreText.text = "Best: " + PlayerPrefs.GetInt ("bestScore").ToString ();
		}
	}

	public void addScore() {
		score++;
		if (score>bestScore ) {
			bestScore = score;
			PlayerPrefs.SetInt ("bestScore", score);
		}
	}

	public void resetScore() {
		score = 0;
		//scoreText.text = "Score: " + score.ToString ();
	}

	public int getHighScore() {
		return bestScore;
	}
}
