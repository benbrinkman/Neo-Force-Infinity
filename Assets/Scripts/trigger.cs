using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

	private Animator anim;
	public bool open;

	bool playSound;
	bool soundPlayed;

	public float timer;

	public GameObject robot;

	
	public AudioClip doorOpens;
	public AudioSource source;
	
	



	void Start () {
		soundPlayed = playSound = false;
		source = GetComponent<AudioSource> ();
		anim = gameObject.GetComponent<Animator> ();
		//this.transform.parent.GetComponent<door>().open
	}


	void Update () {
		anim.SetBool ("open",this.transform.parent.GetComponent<door>().open);

        //door sound
		if (!soundPlayed && playSound) {
			soundPlayed = true;
			source.PlayOneShot(doorOpens,Player.volume);
		}

        //if robot activates trigger
		if ((Vector3.Distance (transform.position, robot.transform.position) < 2)) {
			Open ();
		}

        //reset sounds
		if (this.transform.parent.GetComponent<door> ().open == false) {
			soundPlayed = false;
			playSound = false;
		}

        //close door when area resets
		if (this.transform.parent.GetComponent<door>().open){
			timer--;
			if (timer == 0)
				this.transform.parent.GetComponent<door>().open = false;
		}

	}

    //check robot collisions
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Robot") || col.CompareTag ("Claw") || col.CompareTag ("Cannon")) {
			Open ();
		}
	}

	/*void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Robot") || col.CompareTag ("Claw") || col.CompareTag ("Cannon")) {
			this.transform.parent.GetComponent<door>().open = false;
		}
	}*/

	void Open(){
		playSound = true;
		timer = 500;
		this.transform.parent.GetComponent<door>().open = true;
		//print ("open");
		
	}


}
