using UnityEngine;
using System.Collections;

public class MeleeController : MonoBehaviour {

    [SerializeField] Collider Hitbox;

    [SerializeField] int Damage;

    [SerializeField] float SwingTime;
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0)){

        }
	}

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(.2f);

    }
}
