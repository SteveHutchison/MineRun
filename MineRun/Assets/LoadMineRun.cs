using UnityEngine;
using System.Collections;

public class LoadMineRun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel ()
    {
        Application.LoadLevel("final");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
