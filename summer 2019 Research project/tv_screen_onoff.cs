using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_screen_onoff : MonoBehaviour
{


    public bool start_on = false;
    public bool is_on;
    private bool in_range = false;
    public GameObject button;
    public Material on_color;
    public Material off_color;

    public GameObject hub_raycast;
    private GameObject last_child;
    // Start is called before the first frame update
    void Start()
    {

        
        hub_raycast = GameObject.Find("player/Main Camera");

        is_on = start_on;

        last_child = this.transform.GetChild(3).gameObject;
       
        if (start_on)
        {
            button.GetComponent<Renderer>().material = on_color;
            last_child.SetActive(true);
        }
        else {

            last_child.SetActive(false);
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
        if (in_range) {

            if (last_child.activeSelf == true)
            {

                last_child.SetActive(false);
                button.GetComponent<Renderer>().material = off_color;
                is_on = false;
            }
            else {


                last_child.SetActive(true);
                button.GetComponent<Renderer>().material = on_color;
                is_on = true;
            }

        }
    }
    //*/
    public void shot() {

        if (in_range)
        {

            if (last_child.activeSelf == true)
            {

                last_child.SetActive(false);
                button.GetComponent<Renderer>().material = off_color;
                is_on = false;
            }
            else
            {


                last_child.SetActive(true);
                button.GetComponent<Renderer>().material = on_color;
                is_on = true;
            }

        }

    }
}
