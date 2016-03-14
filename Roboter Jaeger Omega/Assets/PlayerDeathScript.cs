using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDeathScript : MonoBehaviour {

    [SerializeField] AudioSource m_DieSource;

    void Die()
    {
        gameObject.GetComponentInChildren<FirstPersonController>().enabled = false;
        gameObject.GetComponentInChildren<GunMaster>().enabled = false;
        gameObject.GetComponentInChildren<RaycastDetector>().enabled = false;
        m_DieSource.Play();
        gameObject.GetComponentInChildren<ArmsObjectLookAtHack>().enabled = false;
        
    }
}
