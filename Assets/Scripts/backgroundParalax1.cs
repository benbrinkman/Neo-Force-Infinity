﻿using UnityEngine;
using System.Collections;

public class backgroundParalax1 : MonoBehaviour {

	/*
1: -17 -113 Y:0
2: -80.5 -171.25 Y:4
3: 51  -113 Y:4
4: 28.35 -113 Y:3
5: 41.8 -113.4 Y: 2.5
6: 0 -113.1 y:1.7

*/
	public float speed;


	void Update () {

		transform.position -= new Vector3 (speed, 0, 0);
		if (transform.position.x <= -7.9) {
			transform.position = new Vector3(40.1f, -0.25f, 18f);
		}
	}
}
