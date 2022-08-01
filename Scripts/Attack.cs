using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject [] hands;
    // Start is called before the first frame update
    void Start()
    {
        /*hands = GameObject.FindGameObjectsWithTag("Hand");
        foreach(GameObject h in hands)
        {
            Debug.Log(h.name);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        
        /*if (collision.gameObject.name.Equals("Player") && checkCol.enemy1)
        {
            //Debug.Log("Zombie1");
            EnemyController.isAttacking1 = true;
            EnemyController.isAttacking2 = false;
            
        }
        else if(collision.gameObject.name.Equals("Player") && checkCol.enemy2)
        {
            //Debug.Log("Zombie2");
            EnemyController.isAttacking1 = false;
            EnemyController.isAttacking2 = true;
        }*/
        if (collision.gameObject.name.Equals("Player"))
        {
            //PatrolZombie.isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            //PatrolZombie.isAttacking = false;
            //PatrolZombie1.isAttacking = false;
            //AIZombie.isAttacking = false;
        }
    }
}
