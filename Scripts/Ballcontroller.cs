using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0108    // Member hides inherited member; missing new keyword
public class Ballcontroller : MonoBehaviour
{
    public float speed_ = 5f;
    float movement = 0f;
    private Rigidbody2D rigidbody;
    public Transform groundCheckpoint;
    public float groundcheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(movement * speed_, rigidbody.velocity.y);
        isTouchingGround = Physics2D.OverlapCircle(groundCheckpoint.position, groundcheckRadius, groundLayer);
        if(isTouchingGround && Input.GetButtonDown("Jump"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, speed_) ;
        }
    
    }
}
