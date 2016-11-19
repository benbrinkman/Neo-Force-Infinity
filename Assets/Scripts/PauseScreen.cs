using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {
    
	void Update () {
        //put pause screen infront
		if (Player.pause) {
			transform.position = new Vector3 (0.9f, -0.2f, -1);

		}else{

			transform.position = new Vector3 (-100f, -0.2f, -1);

		}
	
	}
}
