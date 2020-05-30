using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Projectile_class : MonoBehaviour
{

    private Vector3 start_point;
    public float speed;
    public float max_distance;
    public float Damage;

    public bool angle_set;
    public float strayFactor; // In degrees, a value of 0 means dead accurate.
    public Vector3 direction;

    // Start is called before the first frame update
    void Awake()
    {
        start_point = this.transform.parent.position;
        this.transform.parent = null;
        this.angle_set = false;
        direction = new Vector3(0, 0, 0);

        //strayFactor = 45;//GunStats.strayFactor;// this.GetComponentInParent<GunStats>().strayFactor;
        //Debug.Log("Old: " + this.transform.rotation);
        var randomNumberY = (float)0.5 * Random.Range(-strayFactor, strayFactor);//Only rotate about the y axis
        this.transform.Rotate(0, randomNumberY, 0, Space.World);
   
        //Debug.Log("y: " + randomNumberY + " New: " + this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        move_update();
    }

    void move_update()
    {

        if (Vector3.Distance(start_point, transform.position) > max_distance)
        {

            Destroy(this.gameObject);

        } else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
