using UnityEngine;
using System.Collections;

public class HealthKitScript : MonoBehaviour {

    GameObject m_Player;

    void Start()
    {
        m_Player = GameObject.Find("Player 1");
    }

	public void Heal()
    {
        m_Player.GetComponent<PlayerHealth>().PlayerCurrentHealth = (int)m_Player.GetComponent<PlayerHealth>().Health;
    }
}
