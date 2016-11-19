using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

    //the load states to get from scene to scene
	public void StartGame() {
		Application.LoadLevel("GameArea");
	}

	public void Menu() {
		Application.LoadLevel("Menu");
	}

	public void LoadingScreen() {
		Application.LoadLevel("LoadingScreen");
	}

	public void MenuDead(){
		if (Player.dead) {
			Application.LoadLevel ("Menu");
		}
	}
	public void MenuPause(){
		if (Player.pause) {
			Application.LoadLevel ("Menu");
		}
	}


	public void StartGameDead() {
		if (Player.dead) {
			Application.LoadLevel ("GameArea");
		}
	}

	public void Leaderboard() {
		Application.LoadLevel("Leaderboard");
	}

	public void Instructions() {
		Application.LoadLevel("Instructions");
	}

	public void ShareScore() {
		if (Player.dead) {
			Application.LoadLevel ("ShareScore");
		}
	}


	public void website(){

		Application.OpenURL ("http://www.facebook.com/neoforceinfinity/");
	}
	public void Update(){
		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
	}


}
