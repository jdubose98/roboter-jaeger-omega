using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] float MaxHealth;

    public float CurrentHealth;

    int Tick = 0;

    bool dead = false;

    [SerializeField] AudioSource DieSource;

	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	

    public void TakeDamage(float damage) {
        if ((CurrentHealth - damage) <= 0 && !dead) { if (gameObject.name != "Security Camera") Die(); else CamDie(); }
        else CurrentHealth = CurrentHealth - damage;
    }

    void Die()
    {
        gameObject.GetComponent<EnemyAttack>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponentInChildren<NavTrigger>().enabled = false;
        StartCoroutine(Rotator(.01f, 1f));
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject, 5);
    }

    void CamDie()
    {
        gameObject.GetComponentInChildren<SecurityCameraScript>().enabled = false;
        gameObject.GetComponent<AudioSource>().Stop();
        DieSource.Play();
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
