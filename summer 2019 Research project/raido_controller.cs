using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raido_controller : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip[] song_files;
    public GameObject button;
    public GameObject[] all_words;
    public Material on_color;
    public Material off_color;
    private bool in_range;
    private AudioSource speaker;
    public bool active;
    public bool start_on;
    public GameObject left;
    public GameObject right;
    private int i = 0;
    public GameObject hub_raycast;
    
    void Start()
    {
        speaker = this.GetComponentInChildren<AudioSource>();

        if (start_on)
        {
            hub_raycast = GameObject.Find("player/Main Camera");
            button.GetComponent<Renderer>().material = on_color;
            active = true;
        }
        else
        {


            active = false;
            button.GetComponent<Renderer>().material = off_color;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, Camera.main.gameObject.transform.position);

        if (distance <= 2.5f)
        {
            in_range = true;
        }
        else
        {
            in_range = false;
        }


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



        if (active && speaker.isPlaying == false) {

            speaker.clip = song_files[i];
                speaker.Play();
            
            
            }

        if (hub_raycast.GetComponent<Fps_cam_look>())
        {
            if (hub_raycast.GetComponent<Fps_cam_look>().fo_click == this.gameObject)
            {

                hub_raycast.GetComponent<Fps_cam_look>().fo_click = null;
                shot();



            }
        }

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
    public void shot() {

        if (in_range)
        {
            if (active)
            {

                active = false;
                button.GetComponent<Renderer>().material = off_color;
                speaker.Pause();
                foreach (GameObject text in all_words)
                {

                    text.GetComponent<UnityEngine.UI.Text>().enabled = false;

                }
            }
            else
            {


                active = true;
                button.GetComponent<Renderer>().material = on_color;
                foreach (GameObject text in all_words)
                {

                    text.GetComponent<UnityEngine.UI.Text>().enabled = true;

                }
            }


        }



    }

}
