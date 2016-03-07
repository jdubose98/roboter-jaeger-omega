using UnityEngine;
using System.Collections;

public class KeyPadScript : MonoBehaviour
{
    [SerializeField]
    GameObject m_wall;

    [SerializeField]
    GameObject m_Keypad;

    public void destroyWall()
    {
        Destroy(m_wall.gameObject);
        Destroy(m_Keypad.gameObject);
    }
}
