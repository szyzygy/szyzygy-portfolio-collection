using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_script : MonoBehaviour
{
    public Transform slotparent;
    public List<GameObject> inventory;
    public List<GameObject> slots;
    public GameObject player;
    



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void make_slot_list()
    {
        foreach (Transform slot in slotparent)
        {
            slots.Add(slot.gameObject);
        }
    }


    public void add_to_slot()
    {
        int n = slots.Count;
        int i = 0;
        foreach (GameObject item in inventory)
        {
            item.transform.SetParent(slots[i].transform);
            i++;
        }

    }

    public void Organize()
    {
        foreach (GameObject item in inventory)
        {
            
            item.GetComponent<Item>().inventorySize();
      
            
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void remove_item(GameObject slot){

        GameObject slot_item;

        if (slot.transform.childCount > 0) {


            if (GameObject.Find("Destination").transform.childCount == 0)
            {

                slot_item = slot.transform.GetChild(0).gameObject;

                inventory.Remove(slot_item);
                slot_item.transform.parent = null;
                slot_item.transform.localScale = slot_item.GetComponent<Item>().normal_scale;
                slot_item.transform.localRotation = Quaternion.Euler(0F, 0F, 0F);
                //slot_item.transform.localPosition = new Vector3(0, 0, 0);
                player.GetComponent<new_movement>().fps_camera.GetComponent<Fps_cam_look>().send_to_hand(slot_item);
                player.GetComponent<new_movement>().close_menu(2);
            }
            else {
                
                    slot_item = GameObject.Find("Destination").transform.GetChild(0).gameObject;


                if (slot_item.GetComponent<Grabbable_object>().belongs_outside) {

                    slot_item.GetComponent<Grabbable_object>().drop();
                    remove_item(slot);

                } else{
                    
                    slot_item.transform.parent = null;
                    remove_item(slot);
                    slot_item.GetComponent<Grabbable_object>().add_to_inventory();
                }
                
            }

        }

    }

    public void put_away_item() {

        GameObject slot_item;

        if (GameObject.Find("Destination").transform.childCount > 0) {


            slot_item = GameObject.Find("Destination").transform.GetChild(0).gameObject;

           slot_item.transform.parent = null;

            slot_item.GetComponent<Grabbable_object>().add_to_inventory();


        }




    }
}
