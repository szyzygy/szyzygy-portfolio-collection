using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonitor : MonoBehaviour
{

    float startTime;
    bool spawnBoss;
    public GameObject boss_1;
    public GameObject radio;
 
    void Start()
    {
        startTime = Time.time;
        spawnBoss = false;

    }

    void Update()
    {
        // Set canDoThis to true after 20 seconds have passed
        if (!spawnBoss  && Time.time - startTime > 80){
            spawnBoss = true;
            boss_1.SetActive(true);
            radio.GetComponent<raido_controller>().play_boss();
            Debug.Log("Boss is Spawning");
        }
    }
}
