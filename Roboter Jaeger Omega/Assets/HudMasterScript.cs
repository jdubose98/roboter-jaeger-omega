using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class HudMasterScript : MonoBehaviour {

    [SerializeField]
    AudioMixerSnapshot m_Undiscovered;

	public void Reload()
    {
        m_Undiscovered.TransitionTo(0);
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
