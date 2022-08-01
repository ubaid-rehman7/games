using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offset;
    public float smoothing_offset;
    Vector3 player_position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (transform.localScale.x> 0f)
        {
            player_position = new Vector3(player_position.x + offset, player_position.y, player_position.z);
        }
        else if (transform.localScale.x < 0f)
        {
            //offset*= -1;
            player_position = new Vector3(player_position.x - offset, player_position.y, player_position.z);
        }
        //transform.position = player_position;
        transform.position = Vector3.Lerp(transform.position, player_position, smoothing_offset * Time.deltaTime);
    }
}
