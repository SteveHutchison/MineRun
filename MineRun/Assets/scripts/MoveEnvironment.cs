using UnityEngine;
using System.Collections;

public class MoveEnvironment : MonoBehaviour {

	Transform cameraTrans;
	GameObject cam;
	public Vector3 pos;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		//update camera position
		cameraTrans = cam.transform;
		//update current position
		pos = transform.position;

		if (pos.x + 38 < cameraTrans.position.x) {
			pos.x += 19*4;

			/*
			if(transform.tag == "Wall")
			{
				pos.x += 26;
				ScoreBoard.AddScore (10);
			}*/
			transform.position = pos;

		}

	}
}
