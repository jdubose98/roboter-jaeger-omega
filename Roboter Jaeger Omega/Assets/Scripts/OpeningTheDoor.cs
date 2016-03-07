using UnityEngine;
using System.Collections;

public class OpeningTheDoor : MonoBehaviour
{
    [SerializeField]
    grabbingTheKey key;

    [SerializeField]
    GameObject m_door;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (key.GotTheKey == true)
            {
                Destroy(m_door);
            }
        }
    }
}
