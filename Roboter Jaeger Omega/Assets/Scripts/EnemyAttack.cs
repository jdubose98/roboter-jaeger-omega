using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    bool debounce = false;

	void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Player" && debounce == false)
        {
            Debug.Log("Found");
            StartCoroutine(DebounceRoutine());
            hit.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(5);
        }
    }

    IEnumerator DebounceRoutine()
    {
        debounce = true;
        yield return new WaitForSeconds(.5f);
        debounce = false;
    }
}
