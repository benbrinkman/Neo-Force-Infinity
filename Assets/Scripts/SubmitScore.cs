using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubmitScore : MonoBehaviour {

	public Text InputField;
	string userID;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		userID = InputField.text.ToString();
	}

	public void Submit(){
        //send player score to the leaderboards
		Highscores.AddNewHighscore(userID, Player.score);
	}

}
