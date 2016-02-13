using UnityEngine;
using System.Collections;

public class ConstantMover : MonoBehaviour {

    public float speed;
    public float curspeed;
    public float maxSpeed;
    public Vector3 rotationLock;
    public float yvel;
    public bool sliding;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        maxSpeed = 8;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sliding = false;
        rotationLock.x = 0;
        rotationLock.y = 0;
        rotationLock.z = 0;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangeSpeed(float change)
    {
        maxSpeed += change;
    }

    void FixedUpdate()
    {
        transform.eulerAngles = rotationLock;

        curspeed = rb2d.velocity.x;

        if (curspeed < maxSpeed)
        {
            rb2d.AddForce(new Vector2(maxSpeed, 0));
        }

        if(curspeed > maxSpeed)
        {
            rb2d.velocity = (new Vector2(maxSpeed, rb2d.velocity.y));
        }

        if(!sliding && curspeed < maxSpeed)
        {
            rb2d.velocity = (new Vector2(maxSpeed, rb2d.velocity.y));
        } 
    }
}
