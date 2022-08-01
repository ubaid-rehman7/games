using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tryyy : MonoBehaviour
{
    // Start is called before the first frame update
    private float distance = 0.5f;
    private float offset = 0.5f;

    void Update()
    {
        RaycastHit hit;

        Ray footstepRay = new Ray(transform.position + (Vector3.up * offset), Vector3.right); // FIX: added an offset

        if (Physics.Raycast(footstepRay, out hit, distance + offset, LayerMask.GetMask("Ground", "Player"))) // FIX: added a LayerMask
        {
            if (hit.collider.tag == "Ground")
            {
                Debug.Log("Player is standing on the ground");
            }
            else if (hit.collider.tag == "Player")
            {
                Debug.Log("Player is colliding with zombie");
            }
        }
    }


}
