using UnityEngine;
using System.Collections;

public class CrosshairsToPosition : MonoBehaviour {

    [SerializeField]
    Transform aimer;

	// Update is called once per frame
	void LateUpdate () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            gameObject.transform.position = hit.point;
            gameObject.transform.LookAt(aimer);
            gameObject.transform.Translate(new Vector3(0, 0, 2f));
        }
    }
}
