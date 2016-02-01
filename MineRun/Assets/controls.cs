using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {

    public bool canJump;
    public int jumpStrength;
    private Rigidbody2D rb2d;
    private bool jump;
    private float yvel;
    

    // Use this for initialization
    void Start () {
        canJump = false;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        jump = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (canJump && Input.GetMouseButtonDown(0))
        {
            //rb2d.AddForce(new Vector2(0, 50 * jumpStrength));
            //canJump = false;
            jump = true;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        yvel = rb2d.velocity.y;

        if(yvel < -0.01)
        {
            canJump = false;
        }
    }

    void FixedUpdate()
    {
        if(jump)
        {
            rb2d.AddForce(new Vector2(0, 50 * jumpStrength));
            canJump = false;
            jump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
}
