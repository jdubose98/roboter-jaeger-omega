using UnityEngine;
using System.Collections;

public class ArmsObjectLookAtHack : MonoBehaviour {

    [SerializeField] GameObject FPCLink;

	void FixedUpdate () {
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, FPCLink.transform.rotation, .2f);
    }
}
