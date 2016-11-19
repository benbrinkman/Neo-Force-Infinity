using UnityEngine;
using System.Collections;

public class MagnetStick : MonoBehaviour {

	
	public AudioClip magnetGunShooting;
	public AudioClip shootingImpact;
	public AudioSource source;
	
	public GetMovment getMovement;
	ShootingMagnet landingCheck;
	float speed;
	public GameObject playerAccess;
	
	Vector3 clickedPosition;
	Vector3 movementCoords;
	bool isTouch;
	bool mouse;
	bool shot;
	bool landed;
	
	void Start(){
		isTouch = false;
		mouse = false;
		
		source = GetComponent<AudioSource> ();
		speed = 0.3f;
		landed = false;
		playerAccess = GameObject.FindGameObjectWithTag("Player");
		landingCheck = transform.parent.gameObject.GetComponent<ShootingMagnet>();
	}
	
	void Update () {
		if (!Player.pause) {
			/*
			bool foundTouch = false;
			for (int i = 0; i < Input.touchCount; i++) {
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began) {
					if (!foundTouch) {
						foundTouch = true;
						Vector2 touchPosition = Camera.main.ScreenToWorldPoint (touch.deltaPosition);
						isTouch = true;
						clickedPosition = touchPosition;
					}
				}
			}
		*/
        //get mouse position and create target
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				mouse = true;
				clickedPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
		
		    //move magnet
			if (transform.position.x < -11) {
				transform.position += new Vector3 (0, 10, 0);
			}
		
		
		
		    //check if magnet fired
			if ((mouse || isTouch) && !Player.dead) {
				if (gameObject.tag == ("Magnet" + ShootingMagnet.magnetCounter)) {
					



					if (clickedPosition.x > -3.5) {//if clicked on right side of player
						source.PlayOneShot(magnetGunShooting,1f);
                        //determine where the bullet comes from in relation to player
						if (Player.slide) {
							transform.position = playerAccess.transform.position + new Vector3 (0, 1, 0);
						} else {
							transform.position = playerAccess.transform.position + new Vector3 (1, 2, 0);
						}
					    //fire the projectile
						movementCoords = getMovement.Move (transform.position, clickedPosition, speed);
						mouse = false;
						isTouch = false;
						landed = false;
						shot = true;
					}
				}
			}
		
		
		    //check if the magnet has landed
			for (int i = 1; i < 5; i++) {
				if (gameObject.tag == ("Magnet" + i)) {
					landingCheck.Landed (i, landed);
				}
			}
		
		    //move the magnet
			if (shot) {
				transform.position += movementCoords;
			}
		
			transform.position += SectionSummoner.movement;
		}
	}
	
    //collision detectiong
	void OnTriggerEnter2D (Collider2D col) {
		//print ("collide");
		if ((col.CompareTag ("jumpBarrier")) || (col.CompareTag ("floor"))) {
			landed = true;
			source.PlayOneShot(shootingImpact,Player.volume);
			shot = false;
		}
	}
}
