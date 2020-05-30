using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject quit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (quit.GetComponent<letter_select>().clicked == true)
        {
            quit.GetComponent<MainMenu>().QuitGame();
        }

    }

   
}
