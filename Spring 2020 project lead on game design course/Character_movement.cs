using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour
{


    CharacterController cr;
    public float move_speed;
    public bool move_lock;
    public GameObject inventory_ui;
    public bool menu_open;
    public GameObject gun_parent;
    public GameObject gun_body;
    public GameObject rotator_control;
    public GameObject gun_return;
    public GameObject audio;

    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CharacterController>();
        inventory_ui.GetComponent<Inventory_manager>().make_slot_list();
        //Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!move_lock)
            Move();

        if (Input.GetKeyDown(KeyCode.Escape))                       //open or close options menu
        {
            if (!menu_open)
            {

                menu_open = true;
                //move_lock = true;
                //inventory_ui.SetActive(true);
                inventory_ui.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
                rotator_control.GetComponent<Top_Down_cam_char_look>().halt_mouse_control = true;
                gun_body.transform.localPosition = inventory_ui.GetComponent<Inventory_manager>().gun_loc.transform.localPosition;
                rotator_control.transform.localRotation = gun_return.transform.localRotation;
            }
            else if (menu_open) {

                //move_lock = false;

                menu_open = false;

                inventory_ui.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0, 0, -500000);
                rotator_control.GetComponent<Top_Down_cam_char_look>().halt_mouse_control = false;
                gun_body.transform.localPosition = gun_return.transform.localPosition;
            }

        }

        if (Input.GetMouseButtonDown(0) && !menu_open) { gun_parent.GetComponent<Shooting_control>().Shoot_gun(); }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {

            footsteps(true);

        }
    }

    private void footsteps(bool io)
    {

        if (!audio.GetComponent<AudioSource>().isPlaying && io)
        {

            audio.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            audio.GetComponent<AudioSource>().PlayOneShot(audio.GetComponent<AudioSource>().clip, 1f);

        }
        if (!io)
        {

            audio.GetComponent<AudioSource>().Stop();

        }


    }



    private void Move()
    {

        float horizontal_in = Input.GetAxis("Horizontal") * move_speed;
        float vertical_in = Input.GetAxis("Vertical") * move_speed;

        Vector3 move_forward = transform.forward * vertical_in;
        Vector3 move_sideways = transform.right * horizontal_in;

        cr.SimpleMove(move_forward + move_sideways);


    }


}
