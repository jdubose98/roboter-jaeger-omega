using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDeathScript : MonoBehaviour {

    [SerializeField] AudioSource m_DieSource;

    [SerializeField] Animator DeathScreenAnim;

    public void Die()
    {
        gameObject.GetComponentInChildren<FirstPersonController>().enabled = false;
        gameObject.GetComponentInChildren<GunMaster>().enabled = false;
        gameObject.GetComponentInChildren<RaycastDetector>().enabled = false;
        m_DieSource.Play();
        gameObject.GetComponentInChildren<ArmsObjectLookAtHack>().enabled = false;
        gameObject.transform.Rotate(0, 0, 55);
        DeathScreenAnim.SetTrigger("DEAD");
        
    }
}
