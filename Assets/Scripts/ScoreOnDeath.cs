using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreOnDeath : MonoBehaviour {


	public Text score;
	void Start () {
	
	}
    
	void Update () {
	//display score when player is dead
			if (Player.dead) {
			score.text = " " + Player.score;

		} else {
			score.text = " ";
		}
	}
}
