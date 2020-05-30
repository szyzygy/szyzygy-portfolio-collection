using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag_script : MonoBehaviour
{
    private bool in_range = false;
    public bool status;
    public bool move;
    public GameObject flag;
    public int full_mast_height;
    private int n = 0;
    public GameObject speaker;
    public GameObject hub_raycast;
    


    void Start()
    {

        hub_raycast = GameObject.Find("player/Main Camera");
        this.flag = transform.Find("Plane").gameObject;

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
        if (this.move && this.status == false)
        {
            flag.transform.Translate(0, (float)0.1, 0);
            n++;
            if (n >= full_mast_height)
            {
                this.move = false;
                this.status = true;
                this.flag.GetComponent<Cloth>().randomAcceleration = new Vector3(5, 0, 5);
                this.flag.GetComponent<Cloth>().externalAcceleration = new Vector3(-20, 0, 10);
            }
        }
        if (this.move && this.status == true)
        {
            flag.transform.Translate(0, (float)-0.1, 0);
            n--;
            if (n <= 0)
            {
                this.move = false;
                this.status = false;
                this.flag.GetComponent<Cloth>().randomAcceleration = new Vector3(0, 0, 0);
                this.flag.GetComponent<Cloth>().externalAcceleration = new Vector3(0, 0, 0);
            }
        }
        if (this.move && n ==1) {

            speaker.GetComponent<sound_control>().play_sound();
                
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
        //flag.transform.Translate(0, 5, 0);
        if (in_range)
        {
            //flag.transform.Translate(0, 5, 0);
            this.move = true;
        }
    }
    //*/

    public void shot() {

        if (in_range)
        {
            //flag.transform.Translate(0, 5, 0);
            this.move = true;
        }

    }
}
