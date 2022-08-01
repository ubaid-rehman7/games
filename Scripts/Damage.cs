using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{ 
    Renderer rend;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Hand") && Health.currentHealth>0)
        {
            StartCoroutine("ChangeColor");
        }
    }
    IEnumerator ChangeColor()
    {
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        c.a = 1f;
        rend.material.color = c;
    }
}
