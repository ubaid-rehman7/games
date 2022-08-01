﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolZombie : MonoBehaviour
{
    float speed = 2f, movementDirX, distance = 2;
    new Rigidbody2D rigidbody;
    public bool isAttacking = false;
    Vector3 localScale;
    bool isfacingRight = true;
    Animator anim;
    public Transform groundcheckPoint;
    bool isGrounded;
    float radius = 0.5f;
    public LayerMask groundlayer;
    RaycastHit2D hitLeft, hitRight;
    // Start is called before the first frame update
    void Start()
    {
        movementDirX = 1;
        localScale = transform.localScale;
        rigidbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (9) to get a bit mask
        int layermask = 1 << 9;

        // This would cast rays only against colliders in layer 9.
        // But instead we want to collide against everything except layer 9. 
        // The ~ operator does this, it inverts a bitmask.
        layermask = ~layermask;
        hitLeft = Physics2D.Raycast(transform.position, transform.right, distance, layermask);
        hitRight = Physics2D.Raycast(transform.position, -transform.right, distance, layermask);
           
        isGrounded = Physics2D.OverlapCircle(groundcheckPoint.position, radius, groundlayer);
        if (!isGrounded)
        {
            if (isfacingRight)
            {
                FaceFlipping();
            }
            else if (!isfacingRight)
            {
                FaceFlipping();
            }
        }
        if (!isAttacking)
        {
            rigidbody.velocity = new Vector2(movementDirX * speed, rigidbody.velocity.y);
        }
        else
            rigidbody.velocity = new Vector2(0, 0);
        if (hitLeft == true || hitRight == true)
        {
            anim.SetBool("IsAttacking", true);
        }
        else
            anim.SetBool("IsAttacking", false);
    }
    void FaceFlipping()
    {
        movementDirX *= -1f;
        isfacingRight = !isfacingRight;
        if ((isfacingRight) && localScale.x < 0 || (!isfacingRight && localScale.x > 0))
        {
            localScale.x *= -1f;
        }
        transform.localScale = localScale;
    }
}