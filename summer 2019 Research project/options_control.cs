using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class options_control : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject vol_increase;
    public GameObject vol_decrease;
    public GameObject sen_increase;
    public GameObject sen_decrease;
    public GameObject vol_display;
    public GameObject sen_display;
    public GameObject restart_button;
    public GameObject settings;
    private int i = 100;
    private int timer = 0;
    public float sensitivity_choice = 2f;
    private bool clicked_flg = true;
    

    void Start()
    {
        if (GameObject.Find("settings_immortal")) {
            settings = GameObject.Find("settings_immortal");
        }
         //i = 100;
         timer = 0;
         
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("settings_immortal"))
        {
            settings.GetComponent<Transfer_settings>().volume = AudioListener.volume;
            settings.GetComponent<Transfer_settings>().sensitivity = sensitivity_choice;

        }
            AudioListener.volume = (float)i / 100f;

            vol_display.GetComponent<UnityEngine.UI.Text>().text = i.ToString();
            sen_display.GetComponent<UnityEngine.UI.Text>().text = sensitivity_choice.ToString();

            if (vol_increase.GetComponent<letter_select>().clicked == true)
            {
                if (Input.GetMouseButton(0))
                {
                    timer++;
                    if (timer > 10)
                    {
                        if (i < 100)
                            i++;

                        vol_display.GetComponent<UnityEngine.UI.Text>().text = i.ToString();
                        timer--;
                        clicked_flg = false;
                    }
                }
                else
                {

                    if (clicked_flg)
                    {
                        if (i < 100)
                            i++;

                        vol_display.GetComponent<UnityEngine.UI.Text>().text = i.ToString();
                    }
                    else
                    {
                        clicked_flg = true;
                    }
                    vol_increase.GetComponent<letter_select>().clicked = false;
                    timer = 0;
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (vol_decrease.GetComponent<letter_select>().clicked == true)
            {
                if (Input.GetMouseButton(0))
                {
                    timer++;
                    if (timer > 10)
                    {
                        if (i > 0)
                            i--;

                        vol_display.GetComponent<UnityEngine.UI.Text>().text = i.ToString();
                        timer--;
                        clicked_flg = false;
                    }
                }
                else
                {
                    if (clicked_flg)
                    {
                        if (i > 0)
                            i--;

                        vol_display.GetComponent<UnityEngine.UI.Text>().text = i.ToString();
                    }
                    else
                    {
                        clicked_flg = true;
                    }
                    vol_decrease.GetComponent<letter_select>().clicked = false;
                    timer = 0;
                }
            }

            if (sen_increase.GetComponent<letter_select>().clicked == true)
            {
                if (sensitivity_choice < 5f) { sensitivity_choice++; }
                sen_increase.GetComponent<letter_select>().clicked = false;

            }

            if (sen_decrease.GetComponent<letter_select>().clicked == true)
            {

                if (sensitivity_choice > 1) { sensitivity_choice--; }
                sen_decrease.GetComponent<letter_select>().clicked = false;
            }
        if (restart_button.GetComponent<letter_select>().clicked == true)
        {
            restart_button.GetComponent<letter_select>().clicked = false;

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }



    }
}
