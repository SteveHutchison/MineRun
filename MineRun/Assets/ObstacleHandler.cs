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

	// Use this for initialization
	void Start () {
	    player = GameObject.FindGameObjectWithTag("Player");
        curObstacles = 0;
    }
	
	// Update is called once per frame
	void Update () {
	    if(curObstacles == 0)
        {
            playerPos = player.transform.position;
            rand = Random.Range(0, 3);
            objectPos = playerPos;
            objectPos.x += 15;
            if(rand == 0)
            {
                objectPos.y = 7.5f;
            }
            if (rand == 1)
            {
                objectPos.y = -3.5f;
            }
            if (rand == 2)
            {
                objectPos.y = 5.0f;
            }
            Instantiate(obstacle[rand], objectPos, Quaternion.identity);
            curObstacles++;
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

        if (coll.gameObject.tag == "Solid")
        {
            Destroy(coll.gameObject);
            solid = true;
            curObstacles--;
        }
    }
}
