using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fdein_vol_master : MonoBehaviour
{
    // Start is called before the first frame update
    public float original_volume;
    private bool completed = false;
    void Start()
    {
        completed = false;

        if (GameObject.Find("settings_immortal")) {

            original_volume = GameObject.Find("settings_immortal").GetComponent<Transfer_settings>().volume;
        }
        
        
        AudioListener.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {

            AudioListener.volume += 0.005f;
            if (AudioListener.volume >= original_volume)
            {
                completed = true;


            }

        }

     
    }
}
