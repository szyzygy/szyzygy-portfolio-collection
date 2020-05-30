using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_translate_lock_script : MonoBehaviour
{
    public bool open = false;
    public GameObject gate;
    public GameObject speaker;
    public GameObject key_1;
    public bool move_to_right;
    public int move_distance;
    public string move_direction;
    private int n = 0;
    private int dirction_flag = -1;
    private bool sound_cue = true;
    public bool need_key;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (move_to_right) {

            dirction_flag *= -1;


        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (this.open == true && n <= move_distance)
        {
            switch (move_direction)
            {

                case "x":
                    gate.transform.Translate((.05f * dirction_flag), 0, 0);
                    
                    break;
                case "y":
                    gate.transform.Translate(0, (.05f * dirction_flag), 0);
              
                    break;
                case "z":
                    gate.transform.Translate(0, 0, (.05f * dirction_flag));
            
                    break;
            }
            
            n++;
        }
        if (n > move_distance) 
            this.open = false;

        if (need_key)
        {
            if (key_1.GetComponent<Lock>().event_trigger)
            {
                this.open = true;
                play_sound();
                key_1.GetComponent<Lock>().event_trigger = false;



            }
        }

    }
    public void play_sound() {

        if (sound_cue) {
            speaker.GetComponent<AudioSource>().PlayOneShot(speaker.GetComponent<AudioSource>().clip, 0.5f);
            sound_cue = false;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == key_1.gameObject.name)
        {
            
            this.open = true;
            play_sound();
        }
    }

}
