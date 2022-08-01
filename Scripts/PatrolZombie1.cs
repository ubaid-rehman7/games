using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolZombie1 : MonoBehaviour
{
    float speed = 2f, movementDirX;
    new Rigidbody2D rigidbody;
    public bool isAttacking = false;
    Vector3 localScale;
    bool isfacingRight = true;
    Animator anim;
    public Transform groundcheckPoint;
    bool isGrounded;
    float radius = 0.3f;
    public LayerMask groundlayer;
    //public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
        movementDirX = 1;
        localScale = transform.localScale;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rigidbody.gravityScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
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
        else
        {
            if (!isAttacking)
            {
                rigidbody.velocity = new Vector2(movementDirX * speed, rigidbody.velocity.y);
            }
            else
                rigidbody.velocity = new Vector2(0, 0);
            if (isAttacking)
            {
                anim.SetBool("IsAttacking", true);
            }
            else
                anim.SetBool("IsAttacking", false);
        }
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
