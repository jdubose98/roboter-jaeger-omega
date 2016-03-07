using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
    public Transform target;

    void Start()
    {

    }

    void Update()
    {
        if (target != null)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(target.position);

        }
    }
}