using UnityEngine;
using System.Collections;

public class Highscores : MonoBehaviour {
    //highscore code from tutorial online: https://www.youtube.com/watch?v=KZuqEyxYZCc&list=PLFt_AvWsXl0cgcFnNTo-Qqb9BwikZ-Qtp



    const string privateCode = "zt4OvclwKE2St16cztWozwVJo2mA_7oE-fRRPegIXgkw";
	const string publicCode = "56e988796e51b6150c8f4f8d";
	const string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoresList;
	static Highscores instance;
	displayHighscores highscoresDisplay;


	void Awake(){
		instance = this;
		highscoresDisplay = GetComponent<displayHighscores> ();

	}

	public static void AddNewHighscore(string username, int score){
		instance.StartCoroutine (instance.UploadNewHigscore (username, score));
	}


	IEnumerator UploadNewHigscore(string username, int score){
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			DownloadHighscores();
			print ("Upload Successful");
		}
		else {
			print("Error uploading:" + www.error);
		}
	}

	public void DownloadHighscores(){
		StartCoroutine ("DownloadHigscoresFromDatabase");
	}

	IEnumerator DownloadHigscoresFromDatabase(){
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {

			FormatHighscores (www.text);
			highscoresDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print("Error downloading:" + www.error);
		}
	}

	void FormatHighscores(string textStream){
		string[] entries = textStream.Split (new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];
		for (int i = 0; i < entries.Length; i++) {
			string[] entryInfo = entries [i].Split (new char[]{'|'});
			string username = entryInfo [0];
			int score = int.Parse (entryInfo [1]);
			highscoresList [i] = new Highscore (username, score);
			print (highscoresList [i].username + ":" + highscoresList [i].score);
		}
	}

}



public struct Highscore{
	public string username;
	public int score;

	public Highscore(string _username, int _score){
		username = _username;
		score = _score;
	}
}
