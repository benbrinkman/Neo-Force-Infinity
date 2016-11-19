using UnityEngine;
using System.Collections;

public class FloorControl : MonoBehaviour {

	Vector2 start;
	Vector2 end;
	Vector3 movement;
    
	void Start () {
		start = new Vector2 (16, this.transform.position.y);
		end = new Vector2 (-16, this.transform.position.y);
	}
	
    //move the floor and cieling
	void Update () {
		transform.position += SectionSummoner.movement;
		if (this.transform.position.x < end.x) {
			this.transform.position = start;
		}

	}
}