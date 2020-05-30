using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_exchange_control : MonoBehaviour
{
    public GameObject player;
    public GameObject gun_parent;
    public List<GameObject> gun_components;
    public bool in_inventory;
    public GameObject inventory;
    public bool in_range;
    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, player.gameObject.transform.position);

        if (distance <= 10f)
        {
            in_range = true;
        }
        else
        {
            in_range = false;
        }
    }

    void exchange_mod(UnityEngine.UI.Image mod, int comp) {

        gun_components[comp].GetComponent<UnityEngine.UI.Image>().sprite = mod.sprite;

    }


    private void OnMouseDown()
    {
        if (in_inventory)
        {
            exchange_mod(this.GetComponent<UnityEngine.UI.Image>(), this.GetComponent<mod_identity_class>().component_location);
            //gun_parent.GetComponent<Shooting_control>().List_active(this.gameObject);

            float strayFactor = this.GetComponent<mod_identity_class>().strayFactor;
            //GunStats.UpdateStats(strayFactor);
        }
        else if (in_range)
        {

        
                add_obj_inventory(this.gameObject);
                in_inventory = true;
            

            // add code here to send the parent to inventory, need both to appear to viewer.
            // once in inventory set the in inventory bool to true and clicking it will do a swap
            // also add a distance check here so player cannot pick up stuff from across tha map.
        }


    }


    public void add_obj_inventory(GameObject obj)
    {

        inventory.GetComponent<Inventory_manager>().inventory.Add(obj.transform.parent.gameObject);
        inventory.GetComponent<Inventory_manager>().add_to_slot();

    }

    //*

    //*/
}
