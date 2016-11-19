using UnityEngine;
using System.Collections;

public class deathScreen : MonoBehaviour {
    
	void Start () {
	
	}
	
	void Update () {
	
		if (Player.dead) {
			transform.position = new Vector3 (0.9f, -0.2f, -1);

		}

	}
}
