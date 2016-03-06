using UnityEngine;
using System.Collections;

public class DropObject : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
	    player = GameObject.FindGameObjectWithTag("Player");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (player.transform.position.x > transform.position.x - 8f)
        {
            rb2d.gravityScale = 1;
        }
	}
}
