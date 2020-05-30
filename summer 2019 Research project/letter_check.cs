using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class letter_check : MonoBehaviour
{
    public string ans;
    public string input = null;
    public bool status = false;
    public GameObject[] letters;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        letters = GameObject.FindGameObjectsWithTag("letter_click");
    }

    // Update is called once per frame
    void Update()
    {
        //input is correct
        if (input.Equals(ans))
        {
            this.status = true;
            
        }

        //input is wrong
        if (input.Length >= this.ans.Length && input.Equals(ans) == false)
         {
            
            foreach (GameObject letter in letters)
            {
                
                if (this.count == 0)
                {
                    letter.transform.Find("text_screen_space/Text").GetComponent<Text>().color = Color.red;
                    
                }
                    
                else if (this.count == 10)
                {
                    letter.transform.Find("text_screen_space/Text").GetComponent<Text>().color = Color.white;
                    
                    this.input = string.Empty;
                    letter.GetComponent<letter_select>().status = false;
                   
                }

                
            }

            //time before it changes color
            if (this.count < 10)
            {
                this.count++;
            }
            else
            {
                this.count = 0;
            }


        }

        take_input();
    }

    /**
     * Checks the status of each letter, adds it to input if true or erases that letter if false
     * 
     **/
    public void take_input()
    {
        foreach (GameObject letter in letters)
        {
            if (letter.GetComponent<letter_select>().clicked == true && letter.GetComponent<letter_select>().status == true)
            {
                this.input = this.input + letter.transform.Find("text_screen_space/Text").GetComponent<Text>().text;
                letter.GetComponent<letter_select>().position = this.input.Length - 1;
                letter.GetComponent<letter_select>().clicked = false;
            }
            else if (letter.GetComponent<letter_select>().clicked == true && letter.GetComponent<letter_select>().status == false)
            {
                this.input = this.input.Remove(letter.GetComponent<letter_select>().position, 1);
                foreach (GameObject l in letters)
                {
                    if (l.GetComponent<letter_select>().position > letter.GetComponent<letter_select>().position)
                    {
                        l.GetComponent<letter_select>().position--;
                    }
                }
                letter.GetComponent<letter_select>().position = 0;
                //GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                letter.GetComponent<letter_select>().clicked = false;
            }

        }
    }

 

    

}
