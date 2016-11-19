using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	
	public AudioClip robotShooting;
	public AudioClip robotSlash;
	public AudioClip impact;
	public AudioSource source;
	

	private bool playSound;
	private bool soundPlayed;

	private bool playSoundHit;
	private bool soundPlayedHit;



	public GetMovment getMovement;
	
	//private GameObject player;
	bool claw;
	bool cannon;
	public bool attack;
	private Animator anim2;
	public GameObject robotType;

	float resetTimer;

	Vector3 movementCoords;
	Vector3 startPos;

	public GameObject nearbyMagnet;
	bool death;
	bool stuck;
    bool inverse;

	float magnetNumber;

	float speed;

	void Start () {
        inverse = false;
		playSound = soundPlayed = false;
		source = GetComponent<AudioSource> ();
	//	robotSlash = Resources.Load("robotSlash") as AudioClip;

		startPos = transform.parent.transform.position;
		stuck = false;
		speed = 0.5f;
		death = false;
	//	player = GameObject.FindGameObjectWithTag("Player");
		if (gameObject.tag == ("Claw")) {
			claw = true;
			cannon = false;
		} else if (gameObject.tag == ("Cannon")) {
			claw = false;
			cannon = true;
		} else {
			claw = cannon = false;
		}
		anim2 = gameObject.GetComponent<Animator> ();
	}
	
	void Update(){
		if (!Player.pause) {
			anim2.SetBool ("attack", attack);
			anim2.SetBool ("death", death);
			if (!death) {

                //check for nearby magnets
				for (int i = 1; i < 5; i++) {

                    //check distance of nearby magnets
					nearbyMagnet = GameObject.FindGameObjectWithTag ("Magnet" + i);
					float distanceX = nearbyMagnet.transform.position.x - transform.parent.transform.position.x;
					bool xCheck;
                    bool yCheck;
					if (distanceX <= 4 && distanceX >= -4)
						xCheck = true;
					else 
						xCheck = false;

					//float distanceY = nearbyMagnet.transform.position.y - transform.parent.transform.position.y;

                    //make sure the magnet is within restraints
					if (nearbyMagnet.transform.position.y >= transform.parent.transform.position.y && transform.parent.transform.position.y > -5)
						yCheck = true;
					else
						yCheck = false;

                    //make sure the magnet has landed
					if (xCheck == true && yCheck == true && ShootingMagnet.isLanded [i] == true) {
						//nearbyMagnet.IsLanded();
						death = true;
						movementCoords = getMovement.Move (transform.parent.transform.position, nearbyMagnet.transform.position, speed);
						if (transform.parent.transform.position.x > nearbyMagnet.transform.position.x) {
							inverse = true;
						}
						magnetNumber = i;
						print ("death");
					}
				}
			}
			if (death) {
                //when robot dies
				nearbyMagnet = GameObject.FindGameObjectWithTag ("Magnet" + magnetNumber);
				//print ("Mx: " +nearbyMagnet.transform.position.x + "My: " + nearbyMagnet.transform.position.y); 
				//print ("Rx: " +transform.position.x + "Ry: " + transform.position.y);
				//transform.position = Vector3.MoveTowards(transform.position, nearbyMagnet.transform.position, speed  * Time.deltaTime);
				if (!stuck) {
					if (!inverse)
						transform.parent.transform.position += movementCoords;
					else
						transform.parent.transform.position -= movementCoords;
				}

				if (Vector3.Distance (nearbyMagnet.transform.position, transform.parent.transform.position) < 1 || Vector3.Distance (nearbyMagnet.transform.position, transform.parent.transform.position) > 15 && !stuck) {
					playSoundHit = true;
					stuck = true;
					resetTimer = 400;
					transform.parent.transform.position = nearbyMagnet.transform.position;
				}
			}
	
            //play sounds at correct times
			if (!soundPlayedHit && playSoundHit && !Player.dead) {
				source.PlayOneShot (impact, Player.volume);
				soundPlayedHit = true;
			}

			if (!soundPlayed && playSound && !Player.dead) {
				if (claw)
					source.PlayOneShot (robotSlash, Player.volume);
				if (cannon)
					source.PlayOneShot (robotShooting, Player.volume);
				soundPlayed = true;
			}


			attack = false;
			if (claw) {
				if (transform.parent.transform.position.x < 1.5 && transform.parent.transform.position.x > 0 && transform.parent.transform.position.y > -5) {
					attack = true;
					playSound = true;
				} else {
					attack = false;
				}

			} else if (cannon) {
				if (transform.parent.transform.position.x < 5 && transform.parent.transform.position.x > 0) {
					attack = true;
					playSound = true;
				} else {
					attack = false;
				}
			}
		
			if (stuck) {
				resetTimer--;
				if (resetTimer == 0) {
					Reset ();
				}
			}
		}
	}
    //reset robot variables
	public void Reset (){
        inverse = false;
		soundPlayedHit = false;
		playSoundHit = false;
		soundPlayed = false;
		playSound = false;
		death = false;
		stuck = false;
		transform.parent.transform.position = startPos;
	}

    //if it hits the player
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player") && !death) {
			Player.dead = true;
		}
	}
}
