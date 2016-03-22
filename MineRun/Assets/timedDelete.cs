using UnityEngine;
using System.Collections;

public class timedDelete : MonoBehaviour {

    private float startTime;
    private float curTime;
    private float target;

	// Use this for initialization
	void Start () {
        target = 1.0f;
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        curTime = Time.time - startTime;
        if(curTime > target)
        {
            Destroy(this.gameObject);
        }
	}
}
