using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    float speed = 3f, movementDirX, range = 6f, distToPlayer;
    new Rigidbody2D rigidbody;
    Vector3 localScale;
    //bool isFacingRight = true;
    public static bool isAttacking = false;
    Animator anim;
    public Transform player;
    public GameObject bloodSplash;
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
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= range)
        {
            ChasePlayer();
        }
        else 
        {
            //Debug.Log("Away");
            rigidbody.velocity = new Vector2(0, 0);
            anim.SetFloat("Movement", rigidbody.velocity.x);
        }
        if (isAttacking)
        {
            rigidbody.velocity = new Vector2(0, 0);
            //anim.SetFloat("Movement", rigidbody.velocity.x);
            anim.SetBool("isAttacking", true);
        }
        else 
            anim.SetBool("isAttacking", false);
    }
   /* void FaceFlipping()
    {
        if (movementDirX > 0f)
        {
            isFacingRight = true;
        }
        else if (movementDirX < 0)
            isFacingRight = false;
        if ((isFacingRight) && localScale.x < 0 || (!isFacingRight) && localScale.x > 0)
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }*/
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x && PlayerController.movement != 0f)
        {
            //Debug.Log("Zombie on left side of player");
            rigidbody.velocity = new Vector2(movementDirX * speed, 0);
            
            transform.localScale = new Vector2(localScale.x, localScale.y);
        }
        else if (transform.position.x < -8.21)
        {
            //Debug.Log("Reach at end");
            rigidbody.velocity = Vector2.zero;

            transform.localScale = new Vector2(localScale.x, localScale.y);
            rigidbody.velocity = new Vector2(movementDirX * speed, 0);

        }
        else if (transform.position.x > 11.38)
        {
            //Debug.Log("Reach at end");
            rigidbody.velocity = Vector2.zero;

            transform.localScale = new Vector2(-localScale.x, localScale.y);
            rigidbody.velocity = new Vector2(-movementDirX * speed, 0);

        }
        else if (transform.position.x > player.position.x && PlayerController.movement != 0f)
        {
            //Debug.Log("Zombie on right side of player");
            rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
            anim.SetFloat("Movement", speed);
            transform.localScale = new Vector2(-localScale.x, localScale.y);
        }
        anim.SetFloat("Movement", speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}