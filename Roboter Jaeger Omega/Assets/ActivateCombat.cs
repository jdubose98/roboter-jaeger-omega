using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ActivateCombat : MonoBehaviour {

    [SerializeField] AudioMixer m_Mixer;
    [SerializeField] AudioSource m_CombatMusic;
    [SerializeField] AudioMixerSnapshot m_Discovered;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player") {
        m_CombatMusic.Play();
        m_Discovered.TransitionTo(1); }
    }
}
