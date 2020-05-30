using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move_basic : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject death_point;
    public GameObject spawn_pooint;



    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = player.gameObject.transform.position;
    }

    void cause_death() {



        enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
        enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(death_point.transform.position);
        Destroy(this);

    }


    public void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "bullet")
        {

            // add code to reduce health per bullet here
            // bullet is the other.gameobject
            cause_death();


        }
    }


}
