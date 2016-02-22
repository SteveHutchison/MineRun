using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

    Transform player;
    float offsetX;
    float offsetY;

    // Use this for initialization
    void Start()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");

        player = player_go.transform;

        offsetX = transform.position.x - player.transform.position.x;
        offsetY = transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = player.position.x + offsetX;
       
        //pos.y = player.position.y + offsetY;
        
        //pos.y = player.position.y + offsetY;
        transform.position = pos;
    }
}
