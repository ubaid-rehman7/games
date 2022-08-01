using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public int numberofCoins;
    public Text coinText;
    public float respawn_delay;
    PlayerController playcon;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins:" + numberofCoins;
        playcon = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CoinsCount(int score)
    {
        numberofCoins += score;
        coinText.text = "Coins:" + numberofCoins;
        //Debug.Log(numberofCoins);
    }
    /*public void respawn()
    {
        StartCoroutine("Respawning");
    }
    IEnumerator Respawning()
    {
        yield return new WaitForSeconds(respawn_delay);
        playcon.transform.position = playcon.respawnPoint;
    }*/
    public void respawn()
    {
        StartCoroutine("respawning");
    }
    IEnumerator respawning()
    {
        yield return new WaitForSeconds(2f);
        playcon.transform.position = playcon.respawnPoint;
    }

}
