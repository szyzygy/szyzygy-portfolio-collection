using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class once_letter_chk : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject letters;
    public GameObject door_mover;
    private left_translate_lock_script[] hold;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (letters.GetComponent<letter_check>().status == true)
        {
            door_mover.GetComponent<left_translate_lock_script>().play_sound();

            hold = door_mover.GetComponents<left_translate_lock_script>();

            foreach (left_translate_lock_script h in hold) {

                h.open = true;

            }
        }
    }
}
