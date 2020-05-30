using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return_obj : MonoBehaviour
{

    public GameObject target;
    public Transform home;
    public float leash_dist;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(home.position, target.transform.position);

        if (distance >= leash_dist)
        {
            target.transform.position = home.position;
            target.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        

    }
}
