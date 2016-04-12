using UnityEngine;
using System.Collections;

public class GhostMover : MonoBehaviour
{

    public float speed;
    public float curspeed;
    public float maxSpeed;
    public Vector3 rotationLock;
    public float yvel;
    public bool sliding;
    public GameObject ghost;
    public float startdistance;
    public float curdistance;

    private Rigidbody2D rb2d;

    
    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        //maxSpeed = 8;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sliding = false;
        rotationLock.x = 0;
        rotationLock.y = 0;
        rotationLock.z = 0;
        ghost = GameObject.FindGameObjectWithTag("Ghost");
        startdistance = (transform.position.x - ghost.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        curdistance = (transform.position.x - ghost.transform.position.x);
    }

    public void ChangeSpeed(float change)
    {
        maxSpeed += change;
    }

    public void SetSpeed(float set)
    {
        maxSpeed = set;
    }



    void FixedUpdate()
    {
        transform.eulerAngles = rotationLock;

        curspeed = rb2d.velocity.x;

        if (curspeed < maxSpeed)
        {
            rb2d.AddForce(new Vector2(maxSpeed, 0));
        }

        if (curspeed > maxSpeed)
        {
            rb2d.velocity = (new Vector2(maxSpeed, rb2d.velocity.y));
        }

        if (!sliding && curspeed < maxSpeed)
        {
            rb2d.velocity = (new Vector2(maxSpeed, rb2d.velocity.y));
        }
    }
}
