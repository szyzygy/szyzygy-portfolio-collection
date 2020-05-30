using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Crate : MonoBehaviour
{
    public GameObject check_plane;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (check_plane.GetComponent<basket_check>().completed == true && count < 18)
        {
            this.transform.Rotate(new Vector3(5,0,0));
            this.transform.Translate(0, -0.07f, 0);
            count++;
        }
    }

    
}
