using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag_check : MonoBehaviour
{
    public GameObject flag1;
    public GameObject flag2;
    public bool flag_2_ans;
    public bool flag_1_ans;
    public bool correct_pattern = false;
    //public bool check;
    // Start is called before the first frame update
    void Start()
    {
        //this.flag1 = GameObject.Find("myflag1");
        
        //this.flag2 = GameObject.Find("myflag2");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.flag1.GetComponent<flag_script>().status == flag_1_ans && this.flag2.GetComponent<flag_script>().status == flag_2_ans)
        {
            this.correct_pattern = true;
        } else
        {
            correct_pattern = false;
        }
    }
}
