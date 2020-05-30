using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertical_wipe : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] faders;
    public bool fade_in;
    public bool activate;
    public bool reverse;
    private int i = 0;
    public int n = 0;
    void Start()
    {
        //*
        if (reverse)
        {

            n = faders.Length - 1;
        }
        //*/
    }

    // Update is called once per frame
    void Update()
    {
        if (activate && i < faders.Length)
        {


            faders[n].gameObject.SetActive(fade_in);
            i++;
            if (reverse)
            {
                n--;
            }
            else
            {
                n++;
            }

        }
        else {

            activate = false;
            i = 0;
        }
        
    }


    public void reset()
    {
        n = 0;

        if(reverse)
        n = faders.Length - 1;
    }

}
