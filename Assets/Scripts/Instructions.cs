using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public GameObject pageOne;
	public GameObject pageTwo;
	public GameObject pageThree;

	int page;
	void Start(){
		page = 1;
		pageOne = GameObject.FindGameObjectWithTag ("jumpSlide");
		pageTwo = GameObject.FindGameObjectWithTag ("enemy");
		pageThree = GameObject.FindGameObjectWithTag ("trigger");

	}
    //going through pages
	public void Update(){
		if (page == 1) {
			pageOne.transform.position = new Vector3(0, 0, 0);
			pageTwo.transform.position = new Vector3(10, 10, 0);
			pageThree.transform.position = new Vector3(10, 10, 0);
		}
		else if (page == 2) {
			pageTwo.transform.position = new Vector3(0, 0, 0);
			pageOne.transform.position = new Vector3(10, 10, 0);
			pageThree.transform.position = new Vector3(10, 10, 0);
		}
		else if (page == 3) {
			pageThree.transform.position = new Vector3(0, 0, 0);
			pageTwo.transform.position = new Vector3(10, 10, 0);
			pageOne.transform.position = new Vector3(10, 10, 0);
		}
	}

	public void Add(){
		page++;
		if (page == 4)
			page = 1;

	}
}
