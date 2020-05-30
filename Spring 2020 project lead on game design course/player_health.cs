using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    public int health;
    public GameObject death_ui;
    public GameObject player;
    public GameObject rotator;
    public GameObject intro_ui;
    public GameObject intro_ui_2;
    public int time;
    public int i;

    public List<GameObject> health_ui;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (i > time)
        {
            if (intro_ui.activeSelf == true)
            {
                intro_ui.SetActive(false);
                intro_ui_2.SetActive(true);
                i = 0;
            }else if (intro_ui_2.activeSelf == true) {
                intro_ui_2.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else {


            i++;

        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.tag + other.gameObject.name);

        if(other.gameObject.tag == "enemy")
        {
            
            take_damage();
        }
    }

    void take_damage()
    {
        health -= 1;
        health_ui[health].SetActive(false);
        if (health <= 0)
        {
            cause_death();
        }
    }

    void cause_death()
    {
        death_ui.SetActive(true);
        player.GetComponent<Character_movement>().move_lock = true;
        rotator.GetComponent<Top_Down_cam_char_look>().halt_mouse_control = true;
    }
}
