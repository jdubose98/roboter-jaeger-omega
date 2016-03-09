using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCodeScript : MonoBehaviour
{
    public int RandomPinCode;

    private string m_UserPin;

    [SerializeField] GameObject m_wall;

    [SerializeField] GameObject m_Keypad;

    public RaycastDetector m_ray;

    [SerializeField] GameObject NumberPadPanel;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPerson;


    void Start()
    {
        RandomPinCode = Random.Range(0000, 9999);

        Debug.Log(RandomPinCode);


    }

    public void UserPin1()
    {
        m_UserPin += "1";
    }

    public void UserPin2()
    {
        m_UserPin += "2";
    }

    public void UserPin3()
    {
        m_UserPin += "3";
    }

    public void UserPin4()
    {
        m_UserPin += "4";
    }

    public void UserPin5()
    {
        m_UserPin += "5";
    }

    public void UserPin6()
    {
        m_UserPin += "6";
    }

    public void UserPin7()
    {
        m_UserPin += "7";
    }

    public void UserPin8()
    {
        m_UserPin += "8";
    }

    public void UserPin9()
    {
        m_UserPin += "9";
    }

    public void UserPin0()
    {
        m_UserPin += "0";
    }

    public void Enter()
    {
        if (m_UserPin == RandomPinCode.ToString())
        {


            Destroy(m_wall.gameObject);
            Destroy(m_Keypad.gameObject);
        }
        if (m_UserPin != RandomPinCode.ToString())
        {
            m_UserPin = "";

            NumberPadPanel.SetActive(false);
            firstPerson.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            m_ray.RayStuff = false;

            StartingCoroutine();
        }
    }

    public void CloseThePad()
    {
        NumberPadPanel.SetActive(false);
        firstPerson.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        m_ray.RayStuff = false;

        StartCoroutine("NumpadIssues");    
    }

    IEnumerator NumpadIssues()
    {
        yield return new WaitForSeconds(2f);

        Debug.Log(m_ray.RayStuff);

        m_ray.RayStuff = true;

        Debug.Log("You may get back on the number pad");
    }

    void StartingCoroutine()
    {
        StartCoroutine("NumpadIssues");
    }
}
