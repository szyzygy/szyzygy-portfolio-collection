using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket_check : MonoBehaviour
{

    public GameObject ball_1;
    public int num_shots_to_make;
    public bool completed;
    private int shots_made = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
       
        if (shots_made == num_shots_to_make) {

            completed = true;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.name == ball_1.gameObject.name)
        {
            shots_made++;
            
        }
    }
}
