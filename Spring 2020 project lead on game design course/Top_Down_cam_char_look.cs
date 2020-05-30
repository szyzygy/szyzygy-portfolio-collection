using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_Down_cam_char_look : MonoBehaviour
{
    Vector2 mouse_look;
    Vector2 Smoothing;
    public float rotation_sensitivity = 2f;
    public float smoothing_factor = 2f;
    public bool halt_mouse_control;
    public GameObject top_camera;

    RaycastHit hit;
    Ray ray;
//*/


    public GameObject character;
    public GameObject gun_parent;
    public float speed;

    void Start()
    {
        
        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (!halt_mouse_control)
        {

             ray = top_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
               

                Vector3 direction = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                Quaternion toRotation = Quaternion.LookRotation(direction);
                character.transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, speed * Time.time);



            }


            

        }
    }


    /*
     
     transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, speed * Time.deltaTime);
     
     
     */








}


