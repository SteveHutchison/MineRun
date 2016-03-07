using UnityEngine;
using System.Collections;

public class MoveEnvironment : MonoBehaviour {

	Transform cameraTrans;
	GameObject cam;
	public Vector3 pos;
    private Rigidbody2D rb2d;
    public bool working;

    // Use this for initialization
    void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
        if (transform.tag == "Falling")
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
        }
        working = false;

    }
	
	// Update is called once per frame
	void Update () {
		//update camera position
		cameraTrans = cam.transform;
		//update current position
		pos = transform.position;

		if (pos.x + 38 < cameraTrans.position.x)
        {
			pos.x += 19*4;

            if (transform.tag == "Falling")
            {
                working = true;
                pos.y = 8.2f;
                rb2d.gravityScale = 0;
                rb2d.velocity *= 0;
            }
            transform.position = pos;
		}
	}
}
