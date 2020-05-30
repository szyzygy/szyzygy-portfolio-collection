using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_control : MonoBehaviour
{

    public GameObject bullet_prefab;
    public GameObject end_of_barrel;
    public float refire_time;
    private Transform EOB;
    public GameObject audio;
    public List<GameObject> active_mods;
    public GameObject stats;
   
    
    private float shot_stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            active_mods.Add(audio);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Shoot_gun()
    {
        if (shot_stopwatch + refire_time <= Time.time) {

            shot_stopwatch = Time.time;
            Instantiate(bullet_prefab, end_of_barrel.transform);
            audio.GetComponent<AudioSource>().PlayOneShot(audio.GetComponent<AudioSource>().clip, 1f);
        }

    }

    public void List_active(GameObject mod) {


        active_mods[mod.GetComponent<mod_identity_class>().component_location] = mod.gameObject;

    }

}
