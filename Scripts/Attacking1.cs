using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking1 : MonoBehaviour
{
    PatrolZombie pz;
    private void Start()
    {
        pz = FindObjectOfType<PatrolZombie>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pz.isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pz.isAttacking = false;
        }
    }
}
