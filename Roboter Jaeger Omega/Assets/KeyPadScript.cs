using UnityEngine;
using System.Collections;

public class KeypadScript : MonoBehaviour
{
    [SerializeField]
    GameObject m_wall;

    [SerializeField]
    GameObject m_Keypad;

    [SerializeField] int m_one;
    [SerializeField] int m_two;
    [SerializeField] int m_three;
    [SerializeField] int m_four;
    [SerializeField] int m_five;
    [SerializeField] int m_six;
    [SerializeField] int m_seven;
    [SerializeField] int m_eight;
    [SerializeField] int m_nine;
    [SerializeField] int m_zero;

    private string userPin;


    public void destroyWall()
    {
        Destroy(m_wall.gameObject);
        Destroy(m_Keypad.gameObject);
    }
}
