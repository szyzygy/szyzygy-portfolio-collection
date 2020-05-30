using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fps_cam_look : MonoBehaviour
{
    // Start is called before the first frame update

    /* camera control method 1
    Vector2 rotation = Vector2.zero;
    public float speed = 3;
    //*/

    //*  camera control method 2
    Vector2 mouse_look;
    Vector2 Smoothing;
    public float mouse_sensitivity = 2f;
    public float smoothing_factor = 2f;
    public bool halt_mouse_control;
    public GameObject fpscam;
    public GameObject fo_click;
    public GameObject look_at_object;
    public GameObject hud_pickup;
    public GameObject hud_interact;
    public GameObject hud_take_note;
    public GameObject hud_prompt_shade;
    public Transform dest;
    
    //*/


    GameObject character;


    void Start()
    {
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("settings_immortal"))
        {

            mouse_sensitivity= GameObject.Find("settings_immortal").GetComponent<Transfer_settings>().sensitivity;
        }

        /*
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;
        //*/
        if (!halt_mouse_control) {

            var target = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            target = Vector2.Scale(target, new Vector2(mouse_sensitivity * smoothing_factor, mouse_sensitivity * smoothing_factor));
            Smoothing.x = Mathf.Lerp(Smoothing.x, target.x, 1f / smoothing_factor);
            Smoothing.y = Mathf.Lerp(Smoothing.y, target.y, 1f / smoothing_factor);
            mouse_look += Smoothing;
            mouse_look.y = Mathf.Clamp(mouse_look.y, -90f, 90f);

            transform.localRotation = Quaternion.AngleAxis(-mouse_look.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouse_look.x, character.transform.up);

            check_infront();

            if (Input.GetMouseButtonDown(0)) { shoot(); }

            

        }

    }



    public void send_to_hand(GameObject item) {

        item.gameObject.SetActive(true);

        item.GetComponent<Grabbable_object>().isgrabbed = true;
        GameObject.Find("player/kick_sphere").layer = 8;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        
        
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        dest.localPosition = item.GetComponent<Grabbable_object>().face_distance;
        item.transform.parent = GameObject.Find("Destination").transform;
        item.GetComponent<Item>().Hold();
            


        if (item.GetComponent<Grabbable_object>().enable_rand_rot)
        {

            item.GetComponent<Grabbable_object>().hold_rot = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        }

        item.transform.localRotation = Quaternion.Euler(item.GetComponent<Grabbable_object>().hold_rot);
        
    }

    public void shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit,100f)){

            fo_click = hit.transform.gameObject;
           
        }
    }

    //This function allows the camera to display "pickup", "interact", "note" when player looks at the item and its in range to pick up.
    public void check_infront()
    {
        RaycastHit hit;
        

        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, 4.5f))
        {
            Item script = hit.transform.GetComponent<Item>();

            if (script != null)                                     //Checks if object has "Item" component and displays "pick up" if true
            {
                hud_prompt_shade.SetActive(true);
                hud_pickup.SetActive(true);
            }


            else if (hit.transform.CompareTag("note"))
            {
                hud_prompt_shade.SetActive(true);
                hud_take_note.SetActive(true);
                
            }

           /* else if (hit.transform.CompareTag("pick_up"))
            {
                hud_prompt_shade.SetActive(true);
                hud_pickup.SetActive(true);
            }*/
            else if (hit.transform.CompareTag("interact")) 
            {
                hud_prompt_shade.SetActive(true);
                hud_interact.SetActive(true);
            }
            else
            {                                          // Ray trace is hitting other objects
                hud_prompt_shade.SetActive(false);
                hud_take_note.SetActive(false);
                hud_pickup.SetActive(false);
                hud_interact.SetActive(false);
            }
        }                   
        else
        {                                           // Ray trace is not hitting any object
            hud_prompt_shade.SetActive(false);
            hud_take_note.SetActive(false);
            hud_pickup.SetActive(false);
            hud_interact.SetActive(false);
        }

        
    }
}
