using UnityEngine;
using System.Collections;

public class SecurityCameraScript : MonoBehaviour {

    [SerializeField] Camera cam;
    Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player 1").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        gameObject.transform.LookAt(target);
        gameObject.transform.Rotate(new Vector3(90, 0, 0));

        Ray m_ray = cam.ViewportPointToRay(target.position);
        RaycastHit hit;
        if (Physics.Raycast(m_ray, out hit, 40))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Sighted");
            }
        }
    }


}
