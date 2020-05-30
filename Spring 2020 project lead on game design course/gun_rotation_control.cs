using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_rotation_control : MonoBehaviour
{

    public GameObject rot_center_guide;
    public GameObject gun_parent_canvas;
    public bool facing_left = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //print("rotation is " + rot_center_guide.transform.localRotation.eulerAngles.y);
        if (rot_center_guide.transform.localRotation.eulerAngles.y > 180 && !facing_left)
        {

            flip_gun();
            
        }else if (rot_center_guide.transform.localRotation.eulerAngles.y < 180 && facing_left)
        {

            flip_gun();

        }
    }


    void flip_gun() {

        facing_left = !facing_left;
        gun_parent_canvas.GetComponent<RectTransform>().localScale = new Vector3(

                                                                   gun_parent_canvas.GetComponent<RectTransform>().localScale.x * -1,
                                                                   gun_parent_canvas.GetComponent<RectTransform>().localScale.y,
                                                                   gun_parent_canvas.GetComponent<RectTransform>().localScale.z
                                                                                );


    }
}
