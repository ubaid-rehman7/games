using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCon : MonoBehaviour
{
    float speed = 2f, movementDirX;
    new Rigidbody2D rigidbody;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movementDirX = 1;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(movementDirX * speed, rigidbody.velocity.y);
        anim.SetFloat("Movement", rigidbody.velocity.x);
    }
}