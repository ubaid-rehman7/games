using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health2 : MonoBehaviour
{
    Image healthbar,armorbar;
    float currentHealth, armorHealth,maxHealth=100f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject hbObj = GameObject.FindWithTag("hb");
        if (hbObj != null)
            healthbar = hbObj.GetComponent<Image>();
        GameObject abObj = GameObject.FindWithTag("ab");
        if (abObj != null)
            armorbar = abObj.GetComponent<Image>();
        
        //armorbar.gameObject.SetActive(false);
        currentHealth = maxHealth;
        armorHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Health();
    }
    void Health()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            if(armorHealth>0 && armorHealth <= 100)
            {
                armorHealth -= 10f;
                armorbar.fillAmount = armorHealth / maxHealth;
            }
            else if(currentHealth>=0 && currentHealth <= 100 && armorHealth==0)
            {
                currentHealth-=2f;
                healthbar.fillAmount = currentHealth / maxHealth;
            }
        }        
    }
}
