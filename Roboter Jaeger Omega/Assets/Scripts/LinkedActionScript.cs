using UnityEngine;
using System.Collections;

public class LinkedActionScript : MonoBehaviour {

    [Tooltip("What should this object appear as when hovered over?")]
    public string ObjectName;
    [Tooltip("Can the object be interacted with?")]
    public bool IsInteractive = true;
    [Tooltip("Does this object\"signal\" a script? (Attach a script (InteractionScript) in order to handle this)")]
    [SerializeField] bool m_UseScriptSignaling;
    [Tooltip("The GameObject that is targeted - good for UseScriptSignaling")]
    [SerializeField] GameObject m_targetObject;


    [Tooltip("Is this object animated?")]
    [SerializeField] bool m_Animated = true;
    [Tooltip("What animator controls this object?")]
    [SerializeField] Animator m_ObjectAnimator;
    [Tooltip("What trigger should be set when animating?")]
    [SerializeField] string m_TriggerToSet;

    [Tooltip("Reference to the activity light for visual feedback to a player.")]
    [SerializeField] GameObject m_ActivityLight;
    [Tooltip("Texture used when the system is \"off.\"")]
    [SerializeField] Material m_InactiveTexture;
    [Tooltip("Texture used when the system is \"on.\"")]
    [SerializeField] Material m_ActiveTexture;

    [SerializeField] bool IsToggled;
    public bool LockPlayer = false;

    bool IsActive = false; // Holds "state" of trigger.

    public void OnInteract()
    {
        gameObject.GetComponent<AudioSource>().Play();
        if (m_Animated) m_ObjectAnimator.SetTrigger(m_TriggerToSet);

        if (IsActive)
        {
            IsActive = false;
            if (IsToggled) ToggleLight(false);


            if (m_UseScriptSignaling) m_targetObject.GetComponent<InteractionScript>().TurnOff();
        }
        else
        {
            IsActive = true;
            if (IsToggled) ToggleLight(true);
            if (m_targetObject.activeSelf == false) m_targetObject.SetActive(true);
            if (m_UseScriptSignaling) m_targetObject.GetComponent<InteractionScript>().TurnOn();
        }
    }

    public void ToggleLight(bool toggle)
    {
        if (toggle) m_ActivityLight.GetComponent<Renderer>().material = m_ActiveTexture;
        else m_ActivityLight.GetComponent<Renderer>().material = m_InactiveTexture;
    }
}
