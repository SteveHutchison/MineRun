using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

    Vector3 startPos;
    Vector3 curPos;
    float moveSpeed;
    float width;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        width = 19;
        moveSpeed = 0.05f;
        startPos.x = 12.0f;
	}
	
	// Update is called once per frame
	void Update () {
        curPos = transform.position;
        if(curPos.x <= 12.1f - width * 2)
        {

            curPos.x = startPos.x;
            transform.position = curPos;
        }
        else
        {
            curPos.x -= moveSpeed;
            transform.position = curPos;
        }
	}
}
