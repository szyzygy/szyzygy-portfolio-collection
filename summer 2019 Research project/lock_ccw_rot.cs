using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lock_ccw_rot : MonoBehaviour
{
    public bool open;
    public GameObject gate;
    public GameObject key_1;
    public int num_dgree_to_rot;
    public float pivot_correction;
    private Vector3 pivot_adjust_vec;
    int n = 0;
    private bool sound_cue = true;
    public bool need_key; // for simplicity
    public GameObject speaker;
   

    // Start is called before the first frame update
    void Start()
    {
        pivot_adjust_vec = new Vector3(gate.transform.localPosition.x + pivot_correction, gate.transform.localPosition.y, gate.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.open == true && n <= num_dgree_to_rot)
        {
            //gate.transform.Translate((float)-.1, 0, 0);
            gate.transform.RotateAround(pivot_adjust_vec, Vector3.up,-1f);
          
            n++;
        }
        if (n > num_dgree_to_rot)
            this.open = false;



        if (need_key) {
            if (key_1.GetComponent<Lock>().event_trigger)
            {
                this.open = true;
                play_sound();
                key_1.GetComponent<Lock>().event_trigger = false;



            }
        }
    }

    public void play_sound()
    {

        if (sound_cue)
        {
            speaker.GetComponent<AudioSource>().PlayOneShot(speaker.GetComponent<AudioSource>().clip, 0.5f);
            sound_cue = false;
        }

    }


 

    void OnCollisionEnter(Collision col) // collision code
    {
        // if(col.gameObject.name == "hexagon_key")
        if (col.gameObject.name == key_1.gameObject.name)
        {
            this.open = true;
            play_sound();
        }
    }


}
