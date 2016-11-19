using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {
    //kill player on contact
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			Player.dead = true;
		}
	}
}
