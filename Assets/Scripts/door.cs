using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {


	private Animator anim;
	public bool open;
	
	void Start () {

		open = false;
		anim = gameObject.GetComponent<Animator> ();
	}
	
	void Update () {
		anim.SetBool ("Open",open);
	}

    //kill player if they run into closed door
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player") && !open) {
			Player.dead = true;
		}
	}

}
