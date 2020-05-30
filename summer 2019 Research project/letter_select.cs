using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class letter_select : MonoBehaviour
{
    private bool in_range = false;
    public bool status = false;
    public bool clicked = false;
    public bool color_in;
    public bool use_mouse_d;
    private GameObject letter;
    public GameObject hub_raycast;

    public int position;

    // Start is called before the first frame update
    void Start()
    {
        
        hub_raycast = GameObject.Find("player/Main Camera");
        this.letter = transform.Find("text_screen_space/Text").gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, Camera.main.gameObject.transform.position);

        if (distance <= 5f)
        {
            in_range = true;
        }
        else
        {
            in_range = false;
        }
        if (!use_mouse_d && hub_raycast.GetComponent<Fps_cam_look>()) {
            if (hub_raycast.GetComponent<Fps_cam_look>().fo_click == this.gameObject)
            {

                hub_raycast.GetComponent<Fps_cam_look>().fo_click = null;
                shot();



            }
        }
    }
    //*
    private void OnMouseDown()
    {
        if (in_range && use_mouse_d)
        {
            
            if (this.status == false)
            {
                if (color_in)
                {
                    this.letter.GetComponent<Text>().color = Color.green;
                }
                this.status = true;
               

            } else
            {
                this.letter.GetComponent<Text>().color = Color.white;
                this.status = false;
                
            }
            this.clicked = true;
        }
    }
    //*/
    public void shot() {

        if (in_range && !use_mouse_d)
        {

            if (this.status == false)
            {
                if (color_in)
                {
                    this.letter.GetComponent<Text>().color = Color.green;
                }
                this.status = true;


            }
            else
            {
                this.letter.GetComponent<Text>().color = Color.white;
                this.status = false;

            }
            this.clicked = true;
        }


    }

}
