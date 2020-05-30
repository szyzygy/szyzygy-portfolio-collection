using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class one_off_grader : MonoBehaviour
{
    public GameObject basket_puzzle;
    public GameObject flag_puzzle;
    public GameObject gate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (basket_puzzle.GetComponent<basket_check>().completed == true && flag_puzzle.GetComponent<flag_check>().correct_pattern == true) {
                       
           gate.GetComponent<lock_ccw_rot>().open = true;
            gate.GetComponent<lock_ccw_rot>().play_sound();
        }
    }
}
