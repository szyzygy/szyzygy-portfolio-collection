﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer_settings : MonoBehaviour
{
    // Start is called before the first frame update

    public float volume;
    public float sensitivity;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
