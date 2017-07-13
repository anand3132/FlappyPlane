using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public enum GAMESTATE {
		kMenu,
		kIngame,
		kMaxState
	}

	public UIController uiController;
	public GameObject obstacles;
	public PlaneController plane;
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
		if(Input.touchCount==2|| Input.GetMouseButtonDown(0)) {		
			switchToInGame ();
			// plane.switchPlane();
		}
	}

	private void updateIngameLogic() {
		if(Input.touchCount==2|| Input.GetMouseButtonDown(0)) {
			plane.throttleUp ();
		}
	}

	public void switchToMenu() {
		gameState = GAMESTATE.kMenu;
		obstacles.SetActive (false);

		uiController.switchToMenu ();
		plane.printInfo();
		plane.resetToMenuState();
	}

	public void switchToInGame() {
		gameState = GAMESTATE.kIngame;
		obstacles.SetActive (true);
		uiController.switchToIngame ();
		plane.resetPlaneInIngame ();
	}

	public void switchPlane() {
		print ("Plaine Switched");
	}
}
