using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRobot : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    float speed = 3f, movementDirX, range = 6f, distToPlayer, minX= 16.91f,maxX= 27.56f;
    Vector2 localScale;
    public static bool isAttacking = false, isFacingRight = true;
    public Transform player;
    Animator anim;
    public Transform groundcheckPoint;
    bool isGrounded;
    //float radius = 0.3f;
    public LayerMask groundlayer;
    public GameObject bulletToRight, bulletToLeft;
    float firerate = 1f, nextfire;
    Vector2 bulletpos;
    // Start is called before the first frame update
    void Start()
    {
        movementDirX = 1f;
        rigidbody = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*isGrounded = Physics2D.OverlapCircle(groundcheckPoint.position, radius, groundlayer);
        if (!isGrounded)
        {
            /*if (isfacingRight)
            {
                rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
                transform.localScale = new Vector2(-localScale.x, localScale.y);
            }
            else if (!isfacingRight)
            {
                rigidbody.velocity = new Vector2(movementDirX * speed, 0);
                transform.localScale = new Vector2(localScale.x, localScale.y);
            }
            if (transform.localScale.x > 0f)
            {
                rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
                transform.localScale = new Vector2(-localScale.x, localScale.y);
            }
            else if (transform.localScale.x < 0f)
            {
                rigidbody.velocity = new Vector2(movementDirX * speed, 0);
                transform.localScale = new Vector2(localScale.x, localScale.y);
            }
        }*/
        //else
        {
            distToPlayer = Vector2.Distance(transform.position, player.position);
            if (distToPlayer <= range)
            {
                ChasePlayer();
            }
            else
            {
                //Debug.Log("Zombie is idle");
                rigidbody.velocity = Vector2.zero;
                anim.SetFloat("Movement", rigidbody.velocity.x);
            }
            //if (isAttacking)
            {

                //anim.SetBool("isAttacking", true);
            }
            //else
                //anim.SetBool("isAttacking", false);
        }
        //WhereisFace();
    }
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x && PlayerController.movement != 0f)
        {
            //Debug.Log("Zombie on the left side");
            rigidbody.velocity = new Vector2(movementDirX * speed, 0);
            transform.localScale = new Vector2(localScale.x, localScale.y);
        }
        
        else if (transform.position.x < minX)
        {
            rigidbody.velocity = new Vector2(movementDirX * speed, 0);
            transform.localScale = new Vector2(localScale.x, localScale.y);
        }
        else if (transform.position.x > maxX)
        {
            rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
            transform.localScale = new Vector2(-localScale.x, localScale.y);
        }
        else if (transform.position.x > player.position.x && PlayerController.movement != 0f)
        {
            //Debug.Log("Zombie on the right side");
            rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
            transform.localScale = new Vector2(-localScale.x, localScale.y);

        }
        anim.SetFloat("Movement", speed);
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            fire();
        }
    }
    void WhereisFace()
    {
        isFacingRight = !isFacingRight;
        /*if (transform.localScale.x > 0f)
        {
            isFacingRight = true;
        }
        else if (transform.localScale.x < 0f)
        {
            isFacingRight = false;
        }*/
    }
    //isfacingRight = !isfacingRight;
    /*if ((isfacingRight) && localScale.x < 0 || (!isfacingRight && localScale.x > 0))
    {
        localScale.x *= -1f;
    }
    transform.localScale = localScale;*/
    void fire()
    {
        bulletpos = transform.position;
        if (transform.localScale.x > 0f)
        {
            bulletpos += new Vector2(1, -0.2f);
            Instantiate(bulletToRight, bulletpos, Quaternion.identity);
        }
        else if (transform.localScale.x < 0f)
        {
            bulletpos += new Vector2(-1, -0.2f);
            Instantiate(bulletToLeft, bulletpos, Quaternion.identity);
        }

    }
}