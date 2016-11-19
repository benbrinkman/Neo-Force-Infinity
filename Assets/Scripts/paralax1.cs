using UnityEngine;
using System.Collections;

public class paralax1 : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //move background paralax
        if (!Player.pause) {
			transform.position -= new Vector3 (speed, 0, 0);
			if (transform.position.x <= -8.05) {
				transform.position = new Vector3 (57.5f, 0, 0);
			}
		}
	}
}
