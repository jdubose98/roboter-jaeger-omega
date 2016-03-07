using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RaycastDetector : MonoBehaviour
{

    [SerializeField] Camera m_camera;
    [SerializeField] Text m_InteractText;
    //[SerializeField] GameObject NumberPadPanel;

    public int RandomCode;

    private bool RayStuff;

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
            // NUMPAD
            if (hit.collider.tag.Equals("NumberPad"))
            {   
                Debug.Log("This is a numberpad!");

                if (RayStuff == true)
                {
                    //NumberPadPanel.SetActive(true);
                    firstperson.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                   // NumberPadPanel.SetActive(false);
                    firstperson.enabled = true;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;

                    RayStuff = false;

                    StartCoroutine("NumpadIssues");   
                }

            }
            else
            {
               // NumberPadPanel.SetActive(false);
                firstperson.enabled = true;
            }

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
    IEnumerator NumpadIssues()
    {
        yield return new WaitForSeconds(2f);

        RayStuff = true;

        Debug.Log("You may get back on the number pad");
    }
}
