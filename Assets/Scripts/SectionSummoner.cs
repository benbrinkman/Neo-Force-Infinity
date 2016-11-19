using UnityEngine;
using System.Collections;

public class SectionSummoner : MonoBehaviour {



	public static Vector3 movement;
	public static float speed;

	public static int numberSections;

	int sectionNumber;
	int oldSectionNumber;

	private GameObject currentSection;
	private GameObject oldSection;
	bool platformSelected;
	bool overlap;

	// Use this for initialization
	void Start () {
		numberSections = 16;
		speed = 0.1f;
		movement = new Vector3 (-speed, 0);
		overlap = false;
		sectionNumber = 1;
		oldSectionNumber = 2;
		platformSelected = false;

	}


	void Update () {
		if (!Player.pause) {

            //move platforms
			if (!platformSelected) {
				currentSection = GameObject.FindGameObjectWithTag ("Section" + sectionNumber);
				oldSection = GameObject.FindGameObjectWithTag ("Section" + oldSectionNumber);
				currentSection.transform.position = transform.position;
				platformSelected = true;
			}

            //select a platform when old one moves off screen
			if (currentSection.transform.position.x < -16) {
				oldSectionNumber = sectionNumber;
				while (sectionNumber == oldSectionNumber) {
					if (Player.score < 3000)
						sectionNumber = Random.Range (1, 8);
					else if (Player.score < 5000)
						sectionNumber = Random.Range (1, (numberSections + 1));
					else
						sectionNumber = Random.Range (8, (numberSections + 1));

					print (sectionNumber);
				}
				oldSection = GameObject.FindGameObjectWithTag ("Section" + oldSectionNumber);
				currentSection = GameObject.FindGameObjectWithTag ("Section" + sectionNumber);
				currentSection.transform.position = transform.position;
				overlap = true;
			}
            //place old section in storage below
            //wishing I had just learned to use prefabs
			if (oldSection.transform.position.x < -32) {
				oldSection.transform.position = new Vector2 (16, oldSectionNumber * -12);
				overlap = false;
			}
            //movement
			currentSection.transform.position += movement;
			if (overlap)
				oldSection.transform.position += movement;

		}
	}
}
