using UnityEngine;
using System.Collections;

public class LinkedActionScript : MonoBehaviour {

    public bool IsInteractive = true;
    [SerializeField] GameObject targetObject;
    public string ObjectName;
    [SerializeField] Animator ObjectAnimator;
    [SerializeField] string TriggerToSet;

    public void OnInteract()
    {
        Debug.Log("WE DID A THING");
        ObjectAnimator.SetTrigger(TriggerToSet);
    }
}
