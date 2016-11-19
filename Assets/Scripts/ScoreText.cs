using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {

	void Update () {
        //display death screen on death
		if (Player.dead) {
			transform.position = new Vector3 (-10, -10, -10);
		}
	}
}
