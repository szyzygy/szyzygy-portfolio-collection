using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_object : MonoBehaviour
{


    //public GameObject main_player;
    //private bool holding_flag = false;
    public bool in_range = false;
    public Transform dest;
    public Vector3 face_distance;
    public Vector3 hold_rot;
    public bool isgrabbed = false;
    public bool enable_rand_rot = false;
    public GameObject hub_raycast;
    public bool is_note;
    public bool belongs_outside; // flag for allowing objects to stay out of the inventory
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {

        hub_raycast = GameObject.Find("player/Main Camera");


    }
    private void Update()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, Camera.main.gameObject.transform.position);

        if (distance <= 4.5f) 
        {
            in_range = true;
        }
        else {
            in_range = false;
        }

        ///////////////////////////////////////////// raycast grabbing section /////////////////////////////////////////////
        //*
     



        if (hub_raycast.GetComponent<Fps_cam_look>())
        {
            if (hub_raycast.GetComponent<Fps_cam_look>().fo_click == this.gameObject)
            {

                hub_raycast.GetComponent<Fps_cam_look>().fo_click = null;
                shot();



            }
        }
        //*/
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }

    public void drop()
    {
        isgrabbed = false;

        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        this.transform.parent = null;
    }

    /*
    void OnMouseDown()
    {
        if (isgrabbed)
        {
            drop();
            GameObject.Find("player/kick_sphere").layer = 9;
        }
        /*
        else if (in_range)
        {
            isgrabbed = true;
            GameObject.Find("player/kick_sphere").layer = 8;
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().detectCollisions = true;


            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            dest.localPosition = face_distance;
            this.transform.position = dest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
            this.transform.localRotation = Quaternion.Euler(hold_rot);
            
            //this.transform.SetParent(Camera.main.gameObject.transform);
            
        }
        //remove lower line to diable on mouse down 
        
    }
    //*/

    public void shot() {

        if (isgrabbed)
        {
            drop();
            GameObject.Find("player/kick_sphere").layer = 9;
        }
       
        else if (in_range)
        {
            if (is_note)
            {
                pickup_note();
            }
            else
            {
                // inventory code

                if (!belongs_outside)
                {
                    add_to_inventory();
                }
                else
                {

                    //* // single pick up code
                    inventory.GetComponent<inventory_script>().put_away_item();
                    isgrabbed = true;
                    GameObject.Find("player/kick_sphere").layer = 8;
                    this.GetComponent<Rigidbody>().useGravity = false;
                    this.GetComponent<Rigidbody>().detectCollisions = true;


                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    dest.localPosition = face_distance;
                    this.transform.position = dest.position;
                    this.transform.parent = GameObject.Find("Destination").transform;

                    if (enable_rand_rot)
                    {

                        hold_rot = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
                    }

                    this.transform.localRotation = Quaternion.Euler(hold_rot);

                    //this.transform.SetParent(Camera.main.gameObject.transform);
                    //*/



                    //this.transform.SetParent(GameObject.Find("Destination").transform);
                    //this.gameObject.SetActive(false);




                    //*/

                }


            }
        }   
            

    }


    /*void OnMouseUp()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        this.transform.parent = null;


    }*/

    /*private void OnCollisionEnter(Collision collision)
    {

        drop();
        GameObject.Find("player/kick_sphere").layer = 9;
    }*/

    private void pickup_note()
    {
        gameObject.SetActive(false);
        this.GetComponent<Note>().addnote();
    }

    public void add_to_inventory() {

        inventory.GetComponent<inventory_script>().inventory.Add(this.gameObject);
        inventory.GetComponent<inventory_script>().add_to_slot();
        inventory.GetComponent<inventory_script>().Organize();

    }

    public void add_obj_inventory(GameObject obj)
    {

        inventory.GetComponent<inventory_script>().inventory.Add(obj);
        inventory.GetComponent<inventory_script>().add_to_slot();
        inventory.GetComponent<inventory_script>().Organize();

    }


}
