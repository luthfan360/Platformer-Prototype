using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform Point_A, Point_B;
    [SerializeField]
    int speed = 5;
    [SerializeField]
    bool switching = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point_B.position, speed * Time.deltaTime);
        }
        else if (switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point_A.position, speed * Time.deltaTime);
        }

        if (transform.position == Point_A.position)
        {
            switching = false;
        }
        else if (transform.position == Point_B.position)
        {
            switching = true;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        other.transform.parent = null;
    }

}
