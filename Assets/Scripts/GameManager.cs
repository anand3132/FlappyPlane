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
			if(!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			{
				switchToInGame ();

			}
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
		plane.resetToMenuState();
		uiController.switchToMenu ();
		//plane.printInfo();
	}

	public void switchToInGame() {
		gameState = GAMESTATE.kIngame;
		obstacles.SetActive (true);
		uiController.switchToIngame ();
		plane.resetPlaneInIngame ();
	}

	public void switchPlane() {
		plane.switchPlane ();
		print ("Plaine Switched");
	}
}
