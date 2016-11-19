using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {


    public AudioClip musicStart;
	public AudioClip musicLoop;
	public AudioSource source;
	float nextUse;
	float delay;
    float subtract;
	
	void Start () {
		delay = 14.769f;
		nextUse = 44;
        subtract = Time.time;
		source = GetComponent<AudioSource> ();

		source.PlayOneShot(musicStart, Player.volume);
	}
	
	void Update () {
		if ((Time.time - subtract) > nextUse){
			nextUse = Time.time -subtract + delay;
			source.PlayOneShot(musicLoop,Player.volume);
		}
	}
}
