using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Audio;

public class PlayerDeathScript : MonoBehaviour {

    [SerializeField] AudioSource m_DieSource;

    [SerializeField] Animator DeathScreenAnim;

    [SerializeField] RandomQuote quoter;

    [SerializeField] AudioMixerSnapshot m_DeathSnapshot;

    [SerializeField] AudioSource DeathMusic;

    public void Die()
    {
        m_DeathSnapshot.TransitionTo(1);
        DeathMusic.Play();
        gameObject.GetComponentInChildren<FirstPersonController>().enabled = false;
        gameObject.GetComponentInChildren<GunMaster>().enabled = false;
        gameObject.GetComponentInChildren<RaycastDetector>().enabled = false;
        m_DieSource.Play();
        gameObject.GetComponentInChildren<ArmsObjectLookAtHack>().enabled = false;
        gameObject.transform.Rotate(0, 0, 55);
        DeathScreenAnim.SetTrigger("DEAD");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        quoter.RandomizeText();
    }
}
