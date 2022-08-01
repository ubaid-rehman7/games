using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f, distance;
    Animator anim;
    new Rigidbody2D rigidbody;
    bool moveRight = true, moveLeft;
    public Transform groundDetection;
    public static bool isAttacking1 = false, isAttacking2 = false;
    RaycastHit2D groundInfo;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("Zombie1"))
        {
            if (!isAttacking1)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

                if (groundInfo.collider == false)
                {
                   
                        if (moveRight == true)
                        {
                            transform.eulerAngles = new Vector3(0, -180, 0);
                            moveRight = false;
                        }
                        else
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            moveRight = true;
                        }
                    
                }
            }
            if (checkCol.enemy1)
            {
                anim.SetBool("IsAttacking", true);
            }
            else if (checkCol.enemy1 == false)
                anim.SetBool("IsAttacking", false);
        }
        if (gameObject.tag.Equals("Zombie2"))
        {
            if (!isAttacking2)
            {

                transform.Translate(Vector2.left * speed * Time.deltaTime);
                groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
                if (groundInfo.collider == false)
                {
                    if (moveLeft == true)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        moveLeft = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                        moveLeft = true;
                    }
                }
            }
            if (checkCol.enemy2 == true)
            {
                anim.SetBool("IsAttacking", true);
            }
            else if (checkCol.enemy2 == false)
                anim.SetBool("IsAttacking", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }
}