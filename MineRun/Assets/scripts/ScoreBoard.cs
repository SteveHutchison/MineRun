using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	
	static int highScore;
	static int Score;

	//GUIText text;

	public void AddScore(int s)
	{
		Score = s;
		if (highScore < Score) {
			highScore = Score;
		}
	}

	// Use this for initialization
	void Start () {
		Score = 0;

		highScore = PlayerPrefs.GetInt("HighScore", 0);
	}


	// Update is called once per frame
	void Update () {
		GetComponent<GUIText>().text = "Score: " + Score + "\nHighScore: " + highScore;
	}

	void OnDestroy()
	{
		PlayerPrefs.SetInt ("HighScore", highScore);
		//PlayerPrefs.Save();
	}


}