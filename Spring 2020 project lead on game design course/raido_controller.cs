using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raido_controller : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip[] song_files;
    public AudioClip victory;
    public AudioClip Boss;
    private bool in_range;
    public AudioSource speaker;
    public bool active;
    public bool start_on;
 
    public int i = 0;
    public int counter = 0;


    void Start()
    {
        //speaker = this.GetComponentInChildren<AudioSource>();

        if (start_on)
        {
            i = Random.Range(0, song_files.Length);
            active = true;
        }
        else
        {


            active = false;
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (left.GetComponent<letter_select>().clicked == true)
        {

            i--;
            speaker.Stop();
            left.GetComponent<letter_select>().clicked = false;
            if (i < 0) { i = song_files.Length - 1; }
        }

        if (right.GetComponent<letter_select>().clicked == true)
        {

            i++;
            right.GetComponent<letter_select>().clicked = false;
            speaker.Stop();
            if (i > song_files.Length - 1) { i = 0; }
        }

        */



        if (active && speaker.isPlaying == false)
        {


            speaker.clip = song_files[i];
            speaker.PlayOneShot(speaker.clip);

            counter++;

        }


        if (counter == 4) {

            i = Random.Range(0, song_files.Length);
        }
      
        /*
        if (hub_raycast.GetComponent<Fps_cam_look>())
        {
            if (hub_raycast.GetComponent<Fps_cam_look>().fo_click == this.gameObject)
            {

                hub_raycast.GetComponent<Fps_cam_look>().fo_click = null;
                shot();



            }
        }
        */
    }
    /*
    private void OnMouseDown()
    {
        if (in_range)
        {
            if (active) {

                active = false;
                button.GetComponent<Renderer>().material = off_color;
                speaker.Pause();
                foreach (GameObject text in all_words) {

                    text.GetComponent<UnityEngine.UI.Text>().enabled = false;

                }
            }
            else {


                active = true;
                button.GetComponent<Renderer>().material = on_color;
                foreach (GameObject text in all_words)
                {

                    text.GetComponent<UnityEngine.UI.Text>().enabled = true;

                }
            }
            

        }
    }
    */

    public void play_vic() {
        speaker.Stop();

        speaker.clip = victory;
        speaker.PlayOneShot(speaker.clip);


    }
    public void play_boss()
    {
        speaker.Stop();
        speaker.clip = Boss;
        speaker.PlayOneShot(speaker.clip);


    }

    public void shot() {

     
            if (active)
            {

                active = false;
                
                speaker.Pause();
              
            }
            else
            {


                active = true;
               
            }


        



    }

}
