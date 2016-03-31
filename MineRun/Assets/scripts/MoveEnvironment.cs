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
        if (transform.tag == "Falling" || transform.tag == "Raising")
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

		if (pos.x + 235.7f < cameraTrans.position.x)
        {
			pos.x += 235.7f * 2;

            if (transform.tag == "Falling")
            {
                working = true;
                pos.y = 7.2f;
                rb2d.gravityScale = 0;
                rb2d.velocity *= 0;
            }
            if (transform.tag == "Raising")
            {
                working = true;
                pos.y = -2.3f;
            }
            transform.position = pos;
		}
	}
}
