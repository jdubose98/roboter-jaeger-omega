using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RaycastDetector : MonoBehaviour
{

    [SerializeField] Camera m_camera;
    [SerializeField] Text m_InteractText;

    public int RandomCode;

    public bool RayStuff;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstperson;

    void Start ()
    {
        m_camera = GetComponentInChildren<Camera>();

        RayStuff = true;

        RandomCode = Random.Range(0, 9);
	}
	
	
	void Update ()
    {
        //Debug.Log(RandomCode);

        Ray ray = new Ray(m_camera.transform.position, m_camera.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.tag.Equals("InteractiveObject"))
            {
                m_InteractText.text = "(E) Interact\n" + hit.collider.gameObject.GetComponent<LinkedActionScript>().ObjectName;
                m_InteractText.gameObject.SetActive(true);


                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<LinkedActionScript>().OnInteract();
                }
            }
            else
            {
                m_InteractText.gameObject.SetActive(false);
            }
        }
	}
}
