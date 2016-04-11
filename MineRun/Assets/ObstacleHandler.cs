using UnityEngine;
using System.Collections;

public class ObstacleHandler : MonoBehaviour {

    public GameObject[] obstacle;
    private GameObject player;
    private int curObstacles;
    private Vector3 playerPos;
    private Vector3 objectPos;
    private int rand;
    public bool solid;
    private Animator ghostAnimator;
    private GameObject ghost1;

    private int lastRand;

    private float startTime;
    public float curTime;
    public float animTime;
    public float runTime;

	// Use this for initialization
	void Start () {
	    player = GameObject.FindGameObjectWithTag("Player");
        ghost1 = GameObject.FindGameObjectWithTag("Ghost");
        ghostAnimator = ghost1.GetComponent<Animator>();
        curObstacles = 1;
        startTime = Time.time;
        animTime = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
	    if(curObstacles == 0)
        {
            playerPos = player.transform.position;
            rand = Random.Range(0, 4);
            while(rand == lastRand)
            {
                rand = Random.Range(0, 4);
            }
            lastRand = rand;
            objectPos = playerPos;
            objectPos.x += 16;
            if(rand == 0)
            {
                //objectPos.y = 8.5f;
                objectPos.x += 2;
                objectPos.y = 0;
                startTime = Time.time;
                ghostAnimator.SetBool("screaming", true);
            }
            if (rand == 1)
            {
                objectPos.y = -4.5f;
                startTime = Time.time;
                ghostAnimator.SetBool("armDown", true);
            }
            if (rand == 2)
            {
                objectPos.y = 0.1f;
            }
            if (rand == 3)
            {
                objectPos.y = -3.2f;
            }
            Instantiate(obstacle[rand], objectPos, Quaternion.identity);
            curObstacles++;
        }
        curTime = Time.time;
        runTime = curTime - startTime;
        if(runTime >= animTime)
        {
            ghostAnimator.SetBool("armDown", false);
            ghostAnimator.SetBool("screaming", false);
        }
    }

    public void DecreaseObs()
    {
        curObstacles--;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Raising")
        {
            Destroy(coll.gameObject);
            curObstacles--;
        }

        if (coll.gameObject.tag == "Falling")
        {
            Destroy(coll.gameObject);
            curObstacles--;
        }

        if (coll.gameObject.tag == "Static")
        {
            Destroy(coll.gameObject);
            curObstacles--;
        }

        if (coll.gameObject.tag == "Solid")
        {
            Destroy(coll.gameObject);
            solid = true;
            curObstacles--;
        }
    }
}
