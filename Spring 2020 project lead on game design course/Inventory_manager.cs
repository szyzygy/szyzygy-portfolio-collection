using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_manager : MonoBehaviour
{


    public Transform R_parent;
    public Transform St_parent;
    public Transform B_parent;
    public Transform U_parent;
    public Transform Sc_parent;


    public GameObject gun_loc;
    public List<GameObject> inventory;
    public List<GameObject> reciver;
    public List<GameObject> Stocks;
    public List<GameObject> Barrels;
    public List<GameObject> unders;
    public List<GameObject> scopes;
    public GameObject player;

    private void Start()
    {
        make_slot_list();
    }

    public void make_slot_list()
    {
        foreach (Transform slot in R_parent)
        {
            reciver.Add(slot.gameObject);
        }

        foreach (Transform slot in B_parent)
        {
            Barrels.Add(slot.gameObject);
        }

        foreach (Transform slot in St_parent)
        {
            Stocks.Add(slot.gameObject);
        }

        foreach (Transform slot in U_parent)
        {
            unders.Add(slot.gameObject);
        }

        foreach (Transform slot in Sc_parent)
        {
            scopes.Add(slot.gameObject);
        }

    }

    public void add_to_slot()
    {
        
        int B = 0;
        int R = 0;
        int St = 0;
        int U = 0;
        int Sc = 0;

        foreach (GameObject item in inventory)
        {
            List<GameObject> hold = new List<GameObject>();

            switch (item.transform.GetChild(0).GetComponent<mod_identity_class>().component_location)
            {
                case 0:
                    hold = Barrels;

                    item.transform.SetParent(hold[B].transform);
                    item.transform.position = hold[B].transform.position;
                    item.GetComponentInChildren<Rigidbody>().useGravity = false;
                    B++;
                    break;
                case 1:
                    hold = reciver;

                    item.transform.SetParent(hold[R].transform);
                    item.transform.position = hold[R].transform.position;
                    item.GetComponentInChildren<Rigidbody>().useGravity = false;
                    R++;

                    break;
                case 2:
                    hold = Stocks;

                    item.transform.SetParent(hold[St].transform);
                    item.transform.position = hold[St].transform.position;
                    item.GetComponentInChildren<Rigidbody>().useGravity = false;
                    St++;

                    break;
                case 3:
                    hold = unders;

                    item.transform.SetParent(hold[U].transform);
                    item.transform.position = hold[U].transform.position;
                    item.GetComponentInChildren<Rigidbody>().useGravity = false;
                    U++;
                    break;
                case 4:
                    hold = scopes;


                    item.transform.SetParent(hold[Sc].transform);
                    item.transform.position = hold[Sc].transform.position;
                    item.GetComponentInChildren<Rigidbody>().useGravity = false;
                    Sc++;
                    break;
            }

          
           

            
        }

    }






}
