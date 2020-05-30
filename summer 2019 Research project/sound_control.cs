using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_control : MonoBehaviour
{
   

    public GameObject speaker;
    public bool mod_pitch;
    private string last_col = null;
    public bool collide_based;
    public bool trigger_based;
    //private bool sound_cue = true;
    public bool playing;

    // Update is called once per frame

    public void play_sound()
    {
        playing = true;
        if (mod_pitch)
        {

            this.GetComponent<AudioSource>().pitch = Random.Range(1.1f, 1.5f);
        }

        
            speaker.GetComponent<AudioSource>().PlayOneShot(speaker.GetComponent<AudioSource>().clip, 0.5f);
           
        

    }

    void OnCollisionEnter(Collision col)
    {

        if (collide_based) {
            play_sound();
            last_col = col.gameObject.name;

        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (trigger_based)
        {
            play_sound();
            last_col = col.gameObject.name;

        }

    }
}
