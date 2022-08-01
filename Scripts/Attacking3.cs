using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking3 : MonoBehaviour
{
    AIZombie aiz;
    private void Start()
    {
        aiz = FindObjectOfType<AIZombie>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            aiz.isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            aiz.isAttacking = false;
        }
    }

}
