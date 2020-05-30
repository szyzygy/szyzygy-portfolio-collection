using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lock_script : MonoBehaviour
{
    public bool open;
    public GameObject gate;
    public GameObject key_1;

    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.open = false;
        //gate = GameObject.Find("gate_1");
      
    }

    // Update is called once per frame
    void Update()
    {
        if (this.open == true && n <= 50)
        {
            gate.transform.Translate((float)-.1, 0,0);
            n++;
        }
        if (n > 50)
            this.open = false;
    }

    void OnCollisionEnter(Collision col)
    {
        // if(col.gameObject.name == "hexagon_key")
        if(col.gameObject.name == key_1.gameObject.name)
        {
            this.open = true;
        }
    }
}
