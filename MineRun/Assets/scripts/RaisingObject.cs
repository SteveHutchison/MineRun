using UnityEngine;
using System.Collections;

public class RaisingObject : MonoBehaviour {

    private GameObject player;
    private GameObject ghost;
    private Rigidbody2D rb2d;
    private bool moving;

    private float startTime;
    private float targetTime;
    private float currentTime;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ghost = GameObject.FindGameObjectWithTag("Ghost");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moving = false;
        startTime = Time.time;
        targetTime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if(currentTime - startTime >= targetTime)
        {
            //ghost.GetComponent<Animator>().SetBool("armDown", false);
        }

        if (player.transform.position.x > transform.position.x - 6.0f && player.transform.position.x < transform.position.x)
        {
            moving = true;  
        }

        if(moving == true)
        {
            startTime = Time.time;
            //ghost.GetComponent<Animator>().SetBool("armDown", true);
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            if(pos.y < -1.3f)
            {
                pos.y += 0.1f;
            }
            if(pos.y >= -1.3f)
            {
                pos.y = -1.3f;
                moving = false;
            }
            rb2d.MovePosition(pos);
        }
    }
}
