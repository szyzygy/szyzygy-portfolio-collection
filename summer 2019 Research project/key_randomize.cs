using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_randomize : MonoBehaviour
{
    public GameObject gate_lock;
    public GameObject[] list_keys;
    public GameObject hint_screen;
    private int i = 0;
    void Start()
    {
        if (list_keys.Length > 0) {

            i = Random.Range(0, (list_keys.Length));
            gate_lock.GetComponent<left_translate_lock_script>().key_1 = list_keys[i];
            hint_screen.GetComponent<text_controller>().readout = "green lock -> " + list_keys[i].gameObject.name;
        }

        
    }

    // Update is called once per frame
  
}
