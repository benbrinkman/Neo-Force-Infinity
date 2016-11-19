using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public static float volume;
	
	public AudioClip run;
	public AudioSource source;
	public static bool pause;

	public static int score;
	public GUIText scoreText;
	public bool grounded;
	public static bool slide;
	public float slideTimer;
	public BoxCollider2D boxCollider;
	public Rigidbody2D playerRigidbody;
	public float jumpPower;
	private Animator anim;
	public static bool dead;
	//bool submitScore;


	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	void Start () {


		pause = false;
		volume = 1;
		//submitScore = false;
		source = GetComponent<AudioSource> ();
		UpdateScore ();
		dead = slide = false;
		score = 0;
		boxCollider = gameObject.GetComponent<BoxCollider2D> ();
		playerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!pause) {
            //mobile touch controls
			playerRigidbody.gravityScale = 3;
			if (Input.touches.Length > 0) {
				Touch t = Input.GetTouch (0);
				if (t.phase == TouchPhase.Began) {
					firstPressPos = new Vector2 (t.position.x, t.position.y);
				}
				if (t.phase == TouchPhase.Ended) {
					secondPressPos = new Vector2 (t.position.x, t.position.y);

					currentSwipe = new Vector3 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

					currentSwipe.Normalize ();

					if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f && secondPressPos.x < 300)
						Jump ();
					//swipe down
					if (currentSwipe.y < -0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f && secondPressPos.x < 300)
						Slide ();
				}
			}

			/*if (dead && !submitScore) {
			//death.transform.position = new Vector3(-0.1, -0.2, 0);
			Highscores.AddNewHighscore("IAmTotallyJosh", score);
			submitScore = true;
		}*/

			if (Input.GetKeyDown ("v") || Input.GetKeyDown ("down") || Input.GetKeyDown ("s")) {
				Slide ();
			}

			if (!dead) {
				score++;
			}
			UpdateScore ();
            //set animation states
			anim.SetBool ("grounded", grounded);
			anim.SetBool ("slide", slide);
			anim.SetBool ("dead", dead);

            //make sure player doesn't rotate
			transform.localEulerAngles = new Vector3 (0, 0, 0);



			if ((Input.GetKeyDown ("space") || Input.GetKeyDown ("up") || Input.GetKeyDown ("w"))) {// && grounded)
				Jump ();
			}

			if (slide) {
                //change to slide mode
				boxCollider.offset = new Vector2 (0f, 0.5f);
				boxCollider.size = new Vector3 (1.8f, 0.97f, 0f);
				slideTimer--;
			} else {
                //change to stand mode
				boxCollider.offset = new Vector2 (0f, 0.985f);
				boxCollider.size = new Vector3 (1.8f, 1.97f, 0f);
			}

            //stop slide after time is up
			if (slideTimer == 0) {
				slide = false;
			}

		
            //removed footstep sounds
			if (!grounded || slide) {
				source.mute = true;
			} else {
				//source.mute = false;
			}

            //movement
			float currentY = this.transform.position.y;

            //player 
			if (dead) {
				this.transform.position += SectionSummoner.movement;
			} else if (this.transform.position.x < -4.1) {
				dead = true;
			} else {
				this.transform.position = new Vector2 (-4, currentY);
			}
			//	if (dead) {
			//print ("dead");
			//Application.LoadLevel("DeathScreen");
			//}
		} else {
			playerRigidbody.gravityScale = 0;
		}

	}

    //set slide
	public void Slide(){
		slide = true;
		slideTimer = 60;
	}

	public void Jump(){
		if (grounded)
			playerRigidbody.AddForce(Vector2.up * jumpPower);
	}


	void UpdateScore()
	{
		if (!dead) {
			scoreText.transform.position = new Vector3 (0.6f, 1, 0);
			scoreText.text = "Score: " + score;
		}
		else {
			scoreText.transform.position = new Vector3(0.5f, 0.699f, 1);
			scoreText.text = "" + score;
		}

	}

	public void Pause(){
		if (!dead) {
			if (pause)
				pause = false;
			else
				pause = true;
		}
	}
	public void UnPause(){
		if (pause) {
			pause = false;
		}
	}
}
