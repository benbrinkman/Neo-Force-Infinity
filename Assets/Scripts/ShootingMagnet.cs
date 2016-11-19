using UnityEngine;
using System.Collections;

public class ShootingMagnet : MonoBehaviour {

	//private Player player;

	public static float magnetCounter;

	public static bool[] isLanded = new bool[5];
	bool isTouch;


	void Start () {
		isTouch = false;
		for (int i = 0; i < 5; i++) {
			isLanded[i] = false;
		}
		magnetCounter = 1;
	}

	void Update () {
		/*bool foundTouch = false;
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch (i);
			if (touch.phase == TouchPhase.Ended && Player.canShoot) {
				if (!foundTouch)
				{
					foundTouch = true;
					Vector2 touchPosition = Camera.main.ScreenToWorldPoint (touch.deltaPosition);
					if (touchPosition.x > -4)
						isTouch = true;
				}
			}
		}
		*/

        //select which magnet is being used to shoot
		if ((Input.GetKeyDown (KeyCode.Mouse0) || isTouch) && !Player.dead) {
			//isTouch = false;
			magnetCounter++;
			if (magnetCounter > 5) {
				magnetCounter = 1;
			}
		}
	}
    //find out which magnet landed
	public void Landed(int identifier, bool landed){
		isLanded [identifier] = landed;
	}
}
