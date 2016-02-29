using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour
{
    [SerializeField]
    float range;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(GameObject.Find("Player 1").GetComponent<Transform>());
        gameObject.transform.Rotate(0, 180, 0);

        var up = transform.TransformDirection(Vector3.up);
        //note the use of var as the type. This is because in c# you 
        // can have lamda functions which open up the use of untyped variables
        //these variables can only live INSIDE a function. 
        RaycastHit hit;
        Debug.DrawRay(transform.position, -up * 2, Color.green);

        if (Physics.Raycast(transform.position, -up, out hit, 2))
        {

            Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.blue);

                
            if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, range))
            {
                if (hit.transform.tag=="Player")
                Debug.Log("hi " + Time.time);
            }
        }
    }

}