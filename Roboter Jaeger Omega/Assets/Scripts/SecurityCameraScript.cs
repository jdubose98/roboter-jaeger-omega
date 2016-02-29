using UnityEngine;
using System.Collections;

public class SecurityCameraScript : MonoBehaviour {

    [SerializeField] Camera cam;
    Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Box007").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        gameObject.transform.LookAt(target);
        transform.Rotate(90, 0, 0);

        if (target.gameObject.GetComponent<Renderer>().IsVisibleFrom(cam))
        {
            Debug.Log("Sighted " + Time.time);
        }
    }


}
