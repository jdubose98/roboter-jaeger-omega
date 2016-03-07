using UnityEngine;
using System.Collections;

public class grabbingTheKey : MonoBehaviour
{
    public bool GotTheKey;

	void Start ()
    {
        GotTheKey = false;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "key")
        {
            Destroy(other.gameObject);
            GotTheKey = true;
        }
    }

}
