using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFiring : MonoBehaviour
{
    public GameObject bulletToRight, bulletToLeft;
    float firerate = 1f, nextfire;
    Vector2 bulletpos;
    
    public GameObject[] ammo;
    int ammoAmount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 2; i++)
        {
            ammo[i].gameObject.SetActive(false);
        }
        ammoAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextfire && ammoAmount > 0)
        {
            nextfire = Time.time + firerate;
            fire();
        }
        //for gun reloading
        if (Input.GetKey(KeyCode.R))
        {
            ammoAmount = 3;
            for (int i = 0; i <= 2; i++)
            {
                ammo[i].gameObject.SetActive(true);
            }
        }
    }
    void fire()
    {
        bulletpos = transform.position;
        if (PlayerController.isfacingRight)
        {
            bulletpos += new Vector2(1, -0.34f);
            Instantiate(bulletToRight, bulletpos, Quaternion.identity);
        }
        else
        {
            bulletpos += new Vector2(-1, -0.34f);
            Instantiate(bulletToLeft, bulletpos, Quaternion.identity);
        }
        ammoAmount -= 1;
        ammo[ammoAmount].gameObject.SetActive(false);
    }
}
