using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Player player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<Player> ();
	}

    //check for different types of ground
	void OnTriggerEnter2D(Collider2D col){
		if ((col.CompareTag ("jumpBarrier")) || (col.CompareTag ("floor"))) {
			player.grounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if ((col.CompareTag ("jumpBarrier")) || (col.CompareTag ("floor"))) {
			player.grounded = true;
		}
	}


	void OnTriggerExit2D(Collider2D col){
		if ((col.CompareTag ("jumpBarrier")) || (col.CompareTag ("floor"))) {
			player.grounded = false;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
