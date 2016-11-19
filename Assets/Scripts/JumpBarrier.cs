using UnityEngine;
using System.Collections;

public class JumpBarrier : MonoBehaviour {
	/*
	Vector2 start;
	Vector2 end;
	public static Vector3 movement;
	static float speed;
*/
	public bool slideNeeded;
	private GameObject player;
	float width;
	public BoxCollider2D boxArea;
	public bool below;


	// Use this for initialization
	void Start () {
		/*speed = 0.1f;
		movement = new Vector3 (-speed, 0);
		start = new Vector2 (40, this.transform.position.y);
		end = new Vector2 (-40, this.transform.position.y);
*/
		below = false;
		boxArea = gameObject.GetComponent<BoxCollider2D> ();
		width = boxArea.size.x;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        //check if player hits a box
		if (slideNeeded && below && !Player.slide) {
			Player.dead = true;
		}

		CheckBelow ();
		if (below) {
			//print ("below");
		}
	}
    //check if the player is underneath of a box
	void CheckBelow(){
		if (player.transform.position.x - (width / 2) > (this.transform.position.x ) && player.transform.position.x + (width / 2) < (this.transform.position.x ) && player.transform.position.y < this.transform.position.y) {
			below = true;
		} else {
			below = false;
		}
	}
}
