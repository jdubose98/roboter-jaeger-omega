using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] float MaxHealth;

    public float CurrentHealth;

    int Tick = 0;

    bool dead = false;

	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	

    public void TakeDamage(float damage) {
        if ((CurrentHealth - damage) <= 0 && !dead) { Die(); }
        else CurrentHealth = CurrentHealth - damage;
    }

    void Die()
    {
        gameObject.GetComponent<RaycastTest>().enabled = false;
        gameObject.GetComponent<movement>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        StartCoroutine(Rotator(.01f, 1f));
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject, 5);
    }

    IEnumerator Rotator(float delay, float angleTick)
    {
        if (Tick <= 90) {
        gameObject.transform.Rotate(0, 0, angleTick);
        Tick++;
        yield return new WaitForSeconds(delay);
        StartCoroutine(Rotator(.01f, 1f)); }
    }

}
