using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
    
	void Update () {
		if(Application.GetStreamProgressForLevel("GameArea") ==1){
			Application.LoadLevel("GameArea");
		}
	}
}
