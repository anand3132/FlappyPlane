using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to controll the flow of our game.
// Created By Anand.A

public class GameManager : MonoBehaviour {
	public enum GAMESTATE {
		kMenu,
		kIngame,
		kMaxState
	}

	// controller references.
	public UIController uiController;
	public ObstacleController obstacleController;
	public PlaneController planeController;
	public GAMESTATE gameState = GAMESTATE.kMenu;

	void Start () {
		switchToMenu ();
	}
	
	void Update () {
		switch (gameState) {
		case GAMESTATE.kMenu: {
				updateMenuLogic ();
			}
			break;
		case GAMESTATE.kIngame: {
				updateIngameLogic ();
			}
			break;
		}
	}

	private void updateMenuLogic() {
		// we can add any logic for menu here. 
	}

	private void updateIngameLogic() {
		if(Input.touchCount == 2 || Input.GetMouseButtonDown(0)) {
			planeController.throttleUp ();
		}
	}

	public void switchToMenu() {
		gameState = GAMESTATE.kMenu;
		obstacleController.switchToMenu();
		planeController.resetToMenuState();
		uiController.switchToMenu ();
	}

	public void switchToInGame() {
		gameState = GAMESTATE.kIngame;
		obstacleController.switchToInGame ();
		uiController.switchToIngame ();
		planeController.resetPlaneInIngame ();
	}

	public void switchPlane() {
		planeController.switchPlane ();
	}
}
