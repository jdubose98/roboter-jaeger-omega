using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
    public Transform target;

    void Start()
    {

    }

    void OnTriggerEntered(Collider hitObject)
    {
        Debug.Log("MEMELORDS");
        if (hitObject.tag == "Player") {
            if (target != null)
            {
                gameObject.GetComponent<NavMeshAgent>().SetDestination(target.position);

            }
        }
    }
}