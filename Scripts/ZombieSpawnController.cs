using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnController : MonoBehaviour
{
    int randZombie, randSpawnPoint, spawnAllowed;
    public Transform[] spawnPoints;
    public GameObject[] zombies;
    AIZombie aiz;
    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = 1;
        InvokeRepeating("SpawnZombie", 0, 5f);
        aiz = FindObjectOfType<AIZombie>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnZombie()
    {
        if (spawnAllowed < 3)
        {
            randSpawnPoint = Random.Range(0, spawnPoints.Length);
            randZombie = Random.Range(0, zombies.Length);
            if(aiz.isAttacking==false)
            Instantiate(zombies[randZombie], spawnPoints[randSpawnPoint].position, Quaternion.identity);
            spawnAllowed++;
        }
    }
}