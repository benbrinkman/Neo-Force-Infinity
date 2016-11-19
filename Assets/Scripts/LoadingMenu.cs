using UnityEngine;
using System.Collections;

public class LoadingMenu : MonoBehaviour {

	public bool load;
	private Animator anim;

	void Start () {
		load = false;
		anim = gameObject.GetComponent<Animator> ();
	}

	public void Load () {
		
		anim.SetBool ("load", load);
		load = true;
	}
}
