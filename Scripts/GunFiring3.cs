using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFiring3 : MonoBehaviour
{
    public GameObject bulletToRight, bulletToLeft;
    float firerate = 0.5f, nextfire;
    Vector2 bulletpos;
    AIRobot air;

    // Start is called before the first frame update
    void Start()
    {
        air = GetComponent<AIRobot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            fire();
        }
      

    }
    void fire()
    {
        bulletpos = transform.position;
        if (air.transform.localScale.x>0f)
        {
            bulletpos += new Vector2(1, -0.2f);
            Instantiate(bulletToRight, bulletpos, Quaternion.identity);
        }
        else if(air.transform.localScale.x < 0f)
        {
            bulletpos += new Vector2(-1, -0.2f);
            Instantiate(bulletToLeft, bulletpos, Quaternion.identity);
        }
      
    }
}
