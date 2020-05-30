using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float move_speed = 10.0f;
    //private int cursor_lock_flg = -1;
    private Rigidbody legs;
    private Vector3 jump = new Vector3(0f, 4f, 0f);
    //private float jump_strength = 2f;
    void Start()
    {
        legs = this.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float forward = Input.GetAxis("Vertical") * move_speed;
        float strafing = Input.GetAxis("Horizontal") * move_speed;
        forward *= Time.deltaTime;
        strafing *= Time.deltaTime;

        transform.Translate(strafing, 0, forward);
        /*
        if (Input.GetKeyDown("space") && this.GetComponent<Rigidbody>().velocity.y == 0)
        {
            legs.AddForce(jump * jump_strength,ForceMode.Impulse);
        }

        
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Camera.main.gameObject.GetComponent<Fps_cam_look>().enabled = false;

        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Camera.main.gameObject.GetComponent<Fps_cam_look>().enabled = true;
        }
        //*/
    }
}
