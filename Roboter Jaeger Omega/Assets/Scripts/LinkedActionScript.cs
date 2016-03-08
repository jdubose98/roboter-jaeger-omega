using UnityEngine;
using System.Collections;

public class LinkedActionScript : MonoBehaviour {

    public bool IsInteractive = true;
    [SerializeField] GameObject targetObject;
    public string ObjectName;
    [SerializeField] Animator ObjectAnimator;
    [SerializeField] string TriggerToSet;
    [SerializeField] GameObject ActivityLight;

    [SerializeField] Material InactiveTexture;
    [SerializeField] Material ActiveTexture;

    bool IsActive = false;

    public void OnInteract()
    {
        gameObject.GetComponent<AudioSource>().Play();
        ObjectAnimator.SetTrigger(TriggerToSet);

        if (IsActive)
        {
            IsActive = false;
            ActivityLight.GetComponent<Renderer>().material = InactiveTexture;
        }
        else
        {
            IsActive = true;
            ActivityLight.GetComponent<Renderer>().material = ActiveTexture;
        }
    }
}
