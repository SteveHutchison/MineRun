using UnityEngine;
using System.Collections;

public class RaisingObject : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D rb2d;
    private bool moving;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > transform.position.x - 8.0f)
        {
            moving = true;
            
        }
        if(moving == true)
        {
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
