using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_control : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject login;
    public GameObject options;
    public GameObject back;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (login.GetComponent<letter_select>().clicked == true)
        {

            Camera.main.gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
            login.GetComponent<letter_select>().clicked = false;



        }

        if (options.GetComponent<letter_select>().clicked == true)
        {

            Camera.main.gameObject.transform.localRotation = Quaternion.Euler(0, -90, 0);
            options.GetComponent<letter_select>().clicked = false;



        }
        if (back.GetComponent<letter_select>().clicked == true)
        {

            Camera.main.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            back.GetComponent<letter_select>().clicked = false;



        }


    }
}
