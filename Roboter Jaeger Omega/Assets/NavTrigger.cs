using UnityEngine;
using System.Collections;

public class NavTrigger : MonoBehaviour {

    [SerializeField] NavMeshAgent agent;
    [SerializeField] EnemyHealth health;

	void OnTriggerStay(Collider hitObject)
    {
        if (hitObject.gameObject.tag == "Player" && health.CurrentHealth > 0 && agent.isActiveAndEnabled)
        {
            agent.SetDestination(hitObject.transform.position);
        }
    }

    void OnTriggerLeave(Collider hitObject)
    {
        if (hitObject.gameObject.tag == "Player" && health.CurrentHealth > 0 && agent.isActiveAndEnabled)
        {
            agent.SetDestination(hitObject.transform.position);
        }
    }
}
