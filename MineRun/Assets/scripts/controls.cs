using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {

    private bool canJump;
    private bool canSlide;
    private Rigidbody2D rb2d;
    private bool jump;
    private bool slide;
    private float yvel;
    private float slideCooldown;
    private float slideSlowdown;
    private float gameStartTime;
    private float slideStartTime;
    private float currentTime;
    private bool sliding;
    private bool decreaseOnce;
    private bool hitDecreaseOnce;
    private bool increaseOnce;

    private bool slow;
    private bool increase;

    public float startdistance;

    public float curdistance;
    public float mindistance;

    public AudioClip[] sfx;
    private AudioSource source;

    private bool canSmash;
    private bool smash;
    private float smashStartTime;
    private float smashCooldown;
    private float smashTime;
    public bool smashing;
    public GameObject broken;
    public Vector3 brokenPos;

    public Animator animator;
    private Animator ghostAnimator;

    public bool hit;
    public float hitloss;
    public int jumpStrength;
    public float targetSlideTime;
    public float slideSpeed;

    private GameObject scoreboard;

    public GameObject ghost;
    private bool endgame;
    public bool endtimer;
    public float targetEnd;

    private float startPosition;
    private float Score;

    // Use this for initialization
    void Start ()
    {
        smash = false;
        canSmash = true;
        smashing = false;
        smashTime = 1.0f;

        gameStartTime = Time.time;
        canJump = false;
        sliding = false;
        canSlide = true;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

        startPosition = transform.position.x;

        animator = GetComponent<Animator>();
        animator.SetBool("jumping", false);
        jump = false;
        slideCooldown = 0.0f;
        slideSlowdown = 3.65f;
        decreaseOnce = false;
        increaseOnce = false;
        hit = false;
        hitDecreaseOnce = false;

        ghost = GameObject.FindGameObjectWithTag("Ghost");

        scoreboard = GameObject.FindGameObjectWithTag("Scoreboard");

        ghostAnimator = ghost.GetComponent<Animator>();

        startdistance = (transform.position.x - ghost.transform.position.x);

    }
	
	// Update is called once per frame
	void Update ()
    {
        Score = transform.position.x - startPosition;
        int score = (int)Score;
        scoreboard.GetComponent<ScoreBoard>().AddScore(score);


        curdistance = (transform.position.x - ghost.transform.position.x);
        if(curdistance <= 3.5f && !endgame)
        {
            ghostAnimator.SetBool("grabbing", true);
            endtimer = true;
        }

        if (curdistance >= 10.5f && !sliding)
        {
            if (ghost != null)
            {
                ghost.GetComponent<GhostMover>().maxSpeed = 10.0f;
                //hit = true;
                //ghostAnimator.SetBool("screaming", true);
            }
            else
            {
                ghost = GameObject.FindGameObjectWithTag("Ghost");
            }
        }
        if (curdistance < 10.5f)
        {
            if (ghost != null)
            {
                ghost.GetComponent<GhostMover>().maxSpeed = 9.5f;
                //hit = true;
                //ghostAnimator.SetBool("screaming", false);
            }
            else
            {
                ghost = GameObject.FindGameObjectWithTag("Ghost");
            }
        }

        if(endtimer)
        {
            currentTime = Time.time;
            targetEnd = currentTime += 1.0f;
            endgame = true;
            endtimer = false;
        }

        if(endgame)
        {
            currentTime = Time.time;
            if(currentTime >= targetEnd)
            {
                Application.LoadLevel("Menu");
            }
        }

        if (canJump && Input.GetMouseButtonDown(0))
        {
            jump = true;
            source.PlayOneShot(sfx[1]);
        }

        if (canSmash && Input.GetMouseButtonDown(2))
        {
            smash = true;
            smashStartTime = Time.time - gameStartTime;
            smashing = true;
            source.PlayOneShot(sfx[0]);
        }

        if (canSlide && Input.GetMouseButtonDown(1))
        {
            startdistance = (transform.position.x - ghost.transform.position.x);
            this.GetComponent<ConstantMover>().ChangeSpeed(slideSpeed);
            this.GetComponent<ConstantMover>().sliding = true;
            canSlide = false;
            currentTime = Time.time - gameStartTime;
            slideStartTime = currentTime;
            sliding = true;
            slideCooldown = 5.0f;
            source.PlayOneShot(sfx[2]);
        }

        if (sliding)
        {
            currentTime = Time.time - gameStartTime;
            if(currentTime - slideStartTime > targetSlideTime)
            {
                this.GetComponent<ConstantMover>().ChangeSpeed(-slideSpeed);
                this.GetComponent<ConstantMover>().sliding = false;
                sliding = false;
                decreaseOnce = true;
            }
        }

        if (smashing)
        {
            currentTime = Time.time - gameStartTime;
            if (currentTime - smashStartTime > smashTime)
            {
                smashing = false;
            }
        }

        if (hit == true)
        {
            if (!sliding && !increaseOnce && !decreaseOnce)
            {
                startdistance = (transform.position.x - ghost.transform.position.x);
            }

            startdistance -= hitloss;
            hitDecreaseOnce = true;
            this.GetComponent<ConstantMover>().ChangeSpeed(-2.5f);
            hit = false;
            if(sliding)
            {
                this.GetComponent<ConstantMover>().ChangeSpeed(-slideSpeed);
                this.GetComponent<ConstantMover>().sliding = false;
                sliding = false;
                decreaseOnce = true;
            }
        }

        if (currentTime - slideStartTime > targetSlideTime && currentTime - slideStartTime < slideSlowdown && decreaseOnce)
        {
            this.GetComponent<ConstantMover>().ChangeSpeed(-2.5f);
            decreaseOnce = false;
            increaseOnce = true;
        }
        /*
        if (currentTime - slideStartTime >= slideSlowdown && increaseOnce)
        {
            this.GetComponent<ConstantMover>().ChangeSpeed(2.5f);
            increaseOnce = false;
        }
        */
        if (curdistance <= startdistance && increaseOnce)
        {
            this.GetComponent<ConstantMover>().ChangeSpeed(2.5f);
            increaseOnce = false;
        }

        if (curdistance <= startdistance && hitDecreaseOnce)
        {
            this.GetComponent<ConstantMover>().SetSpeed(10.0f);
            hitDecreaseOnce = false;

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
            animator.SetBool("jumping", true);
            canJump = false;
            jump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            canJump = true;
            animator.SetBool("jumping", false);
            currentTime = Time.time - gameStartTime;
            if (currentTime - slideStartTime > slideCooldown)
            {
                canSlide = true;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Raising")
        {
            hit = true;
        }

        if (coll.gameObject.tag == "Falling")
        {
            hit = true;
        }

        if (coll.gameObject.tag == "Static")
        {
            hit = true;
        }

        if (coll.gameObject.tag == "Solid")
        {
            if(smashing)
            {
                Destroy(coll.gameObject);
                brokenPos = coll.transform.position;
                Instantiate(broken, brokenPos, Quaternion.identity);
            }
            if(!smashing)
            {
                hit = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Raising")
        {
            hit = false;
        }
    }
}
