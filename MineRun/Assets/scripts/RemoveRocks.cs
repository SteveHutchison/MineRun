using UnityEngine;
using System.Collections;

public class RemoveRocks : MonoBehaviour {

    private GameObject player;
    private float distance;
    private GameObject spawner;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }
	
	// Update is called once per frame
	void Update () {
        distance = (player.transform.position.x - transform.position.x);
        if(distance > 12)
        {
            Destroy(this.gameObject);
            spawner.GetComponent<ObstacleHandler>().DecreaseObs();
        }
	}
}
