using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public static float currentHealth;
    float maxHealth=100f;
    //public GameObject[] hearts;
    Animator anim;
    Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        GameObject imgObj = GameObject.FindWithTag("hb");
        if (imgObj != null)
            healthbar = imgObj.GetComponent<Image>();
        /*hearts = new GameObject[3];
        int index = 1;
        for (int i = 0; i < 3; i++)
        {
            hearts[i] = GameObject.FindWithTag("Heart"+index.ToString());
            hearts[i].gameObject.SetActive(true);
            index++;
        }*/
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Hand"))
        {
            currentHealth-=5f;
            anim.SetTrigger("IsHurting");
            
            healthbar.fillAmount = currentHealth / maxHealth;
            //Heart();
        }
        if (collision.gameObject.tag.Equals("Heart"))
        {
            currentHealth += 10f;
            SoundManager.PlaySound("pickup_health");
            healthbar.fillAmount = currentHealth / maxHealth;
            
            //Heart();
        }
    }
    /*void Heart()
    {
        if(currentHealth>=90 && currentHealth <= 100)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(true);
            hearts[2].gameObject.SetActive(true);
        }
        else if(currentHealth>=60 && currentHealth <= 89)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(true);
            hearts[2].gameObject.SetActive(false);
        }
        else if(currentHealth>=40 && currentHealth <= 59)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(false);
            hearts[2].gameObject.SetActive(false);
        }
        else if(currentHealth>=0 && currentHealth <= 39)
        {
            hearts[0].gameObject.SetActive(false);
            hearts[1].gameObject.SetActive(false);
            hearts[2].gameObject.SetActive(false);
        }
    }*/
}
