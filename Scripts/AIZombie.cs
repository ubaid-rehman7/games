using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIZombie : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    float speed = 2f, movementDirX, range = 6f, disToPlayer, radius;
    Vector2 localScale;
    public Transform player;
    Animator anim;
    [HideInInspector]
    public bool isAttacking = false;
    public LayerMask groundLayer;
    bool isTouchingGround;
    public Transform groundCheckPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movementDirX = 1;
        localScale = transform.localScale;
        radius = 0.3f;
    }
    
    // Update is called once per frame
    void Update()
    { 
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, radius, groundLayer);
        if (!isTouchingGround)
        {
            if (transform.localScale.x < 0f)
            {
                rigidbody.velocity = new Vector2(movementDirX * speed, 0);
                transform.localScale = new Vector2(localScale.x, localScale.y);
            }
            else if (transform.localScale.x > 0f)
            {
                rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
                transform.localScale = new Vector2(-localScale.x, localScale.y);      
            }
        }
        else if (isTouchingGround)
        {
            disToPlayer = Vector2.Distance(transform.position, player.position);
            if (disToPlayer <= range)
            {
                ChasePlayer();
            }
            else
            {
                rigidbody.velocity = Vector2.zero;
                anim.SetFloat("Movement", rigidbody.velocity.x);
            }
            if (isAttacking)
            {
                rigidbody.velocity = Vector2.zero;
                anim.SetBool("isAttacking", true);
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }
        }
    }
    public void ChasePlayer()
    {
        if (PlayerController.movement == 0f)
        {
            return;
        }
        else if (transform.position.x < player.position.x)        //zombie is left from player
        {
            rigidbody.velocity = new Vector2(movementDirX * speed, 0);   
            transform.localScale = new Vector2(localScale.x, localScale.y);
            anim.SetFloat("Movement", speed);
        }
        else if (transform.position.x > player.position.x)       //zombie is right from player
        {
            rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
            transform.localScale = new Vector2(-localScale.x, localScale.y);
            anim.SetFloat("Movement", speed);
        }    
    }
}