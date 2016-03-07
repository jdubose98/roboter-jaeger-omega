using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    bool debounce = false;

	void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("Found");
            hit.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(5);
        }
    }
}
