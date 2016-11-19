using UnityEngine;
using System.Collections;

public class TargetFramRate : MonoBehaviour {
    
    //limit framerate
	void Start () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
	}
	
	void Update () {
	
	}
}
