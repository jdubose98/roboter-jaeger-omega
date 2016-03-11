using UnityEngine;
using System.Collections;

public class LinkedActionScript : MonoBehaviour {

    [Tooltip("What should this object appear as when hovered over?")]
    public string ObjectName;
    [Tooltip("Can the object be interacted with?")]
    public bool IsInteractive = true;
    [Tooltip("Does this object\"signal\" a script? (Attach a script (InteractionScript) in order to handle this)")]
    [SerializeField] bool UseScriptSignaling;
    [Tooltip("The GameObject that is targeted - good for UseScriptSignaling")]
    [SerializeField] GameObject targetObject;


    [Tooltip("Is this object animated?")]
    [SerializeField] bool Animated = true;
    [Tooltip("What animator controls this object?")]
    [SerializeField] Animator ObjectAnimator;
    [Tooltip("What trigger should be set when animating?")]
    [SerializeField] string TriggerToSet;

    [Tooltip("Reference to the activity light for visual feedback to a player.")]
    [SerializeField] GameObject ActivityLight;
    [Tooltip("Texture used when the system is \"off.\"")]
    [SerializeField] Material InactiveTexture;
    [Tooltip("Texture used when the system is \"on.\"")]
    [SerializeField] Material ActiveTexture;

    [SerializeField] bool IsToggled;
    public bool LockPlayer = false;

    bool IsActive = false; // Holds "state" of trigger.

    public void OnInteract()
    {
        gameObject.GetComponent<AudioSource>().Play();
        if (Animated) ObjectAnimator.SetTrigger(TriggerToSet);

        if (IsActive)
        {
            IsActive = false;
            if (IsToggled) ToggleLight(false);


            if (UseScriptSignaling) targetObject.GetComponent<InteractionScript>().TurnOff();
        }
        else
        {
            IsActive = true;
            if (IsToggled) ToggleLight(true);
            if (targetObject.activeSelf == false) targetObject.SetActive(true);
            if (UseScriptSignaling) targetObject.GetComponent<InteractionScript>().TurnOn();
        }
    }

    public void ToggleLight(bool toggle)
    {
        if (toggle) ActivityLight.GetComponent<Renderer>().material = InactiveTexture;
        else ActivityLight.GetComponent<Renderer>().material = ActiveTexture;
    }
}
