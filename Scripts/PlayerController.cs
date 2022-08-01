using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jump_speed;
    public static float movement;
    new Rigidbody2D rigidbody;
    public Transform groundcheckPoint;
    public float radius;
    public LayerMask groundlayer;
    bool isTouchingground;
    Animator anim;
    public static bool isfacingRight = true;
    [HideInInspector]
    public Vector3 respawnPoint;
    LevelManager lm;    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lm = FindObjectOfType<LevelManager>();
        respawnPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        isTouchingground = Physics2D.OverlapCircle(groundcheckPoint.position, radius, groundlayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isfacingRight = true;
        }
        else if (movement < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            isfacingRight = false;
        }
        rigidbody.velocity = new Vector2(speed * movement, rigidbody.velocity.y);
        if (Input.GetButtonDown("Jump") && isTouchingground)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump_speed);
            
            SoundManager.PlaySound("jump");
        }
        anim.SetFloat("Movement", Mathf.Abs(rigidbody.velocity.x));
        anim.SetBool("IsJumping", isTouchingground);
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("IsSliding", true);   
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("IsSliding", false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("FallDetector"))
        {
            lm.respawn();
        }
        else if (collision.gameObject.tag.Equals("CheckPoint"))
        {
            respawnPoint = collision.transform.position;
        }
    }
}
