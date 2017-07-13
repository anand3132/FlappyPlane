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

	// scoring systems
	int score=10;
	int bestScore=10;

	// Use this for initialization
	void Start () {
		bestScore = PlayerPrefs.GetInt ("bestScore");
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
		scoreText.text = "score: " + score;
		bestScoreText.text = "Best: " + PlayerPrefs.GetInt ("bestScore");
		tapText.text = "";
		menuButton.gameObject.SetActive(true);
		switchPlaneButton.gameObject.SetActive(false);
		flappyBanner.gameObject.SetActive(false);
		tap.gameObject.SetActive (false);
	}

	public void addScore(int score) {
		score++;
		if (score > bestScore) {
			PlayerPrefs.SetInt ("bestScore", score);
			bestScore = score;
		}
	}

	public void resetScore() {
		score = 0;
		scoreText.text = "score: " + score;
	}

	public int getHighScore() {
		return bestScore;
	}
}
