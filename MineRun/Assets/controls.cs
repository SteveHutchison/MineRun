using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {

    private bool canJump;
    private bool canSlide;
    public int jumpStrength;
    private Rigidbody2D rb2d;
    private bool jump;
    private bool slide;
    private float yvel;

    public float slideCooldown;
    private float gameStartTime;
    private float slideStartTime;
    private float currentTime;
    public float targetSlideTime;
    private bool sliding;
    public float slideSpeed;
    

    // Use this for initialization
    void Start () {
        gameStartTime = Time.time;
        canJump = false;
        sliding = false;
        canSlide = true;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        jump = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (canJump && Input.GetMouseButtonDown(0))
        {
            jump = true;
        }

        if (canSlide && Input.GetMouseButtonDown(1))
        {
            this.GetComponent<ConstantMover>().ChangeSpeed(slideSpeed);
            this.GetComponent<ConstantMover>().sliding = true;
            canSlide = false;
            currentTime = Time.time - gameStartTime;
            slideStartTime = currentTime;
            sliding = true;
        }

        if (sliding)
        {
            currentTime = Time.time - gameStartTime;
            if(currentTime - slideStartTime > targetSlideTime)
            {
                this.GetComponent<ConstantMover>().ChangeSpeed(-slideSpeed);
                this.GetComponent<ConstantMover>().sliding = false;
                sliding = false;
            }
        }

        currentTime = Time.time - gameStartTime;
        if (currentTime - slideStartTime > slideCooldown)
        {
            canSlide = true;
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

        if(canJump == false)
        {
            canSlide = false;
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
            currentTime = Time.time - gameStartTime;
            if (currentTime - slideStartTime > slideCooldown)
            {
                canSlide = true;
            }
        }
    }
}
