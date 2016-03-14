using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {

    [SerializeField] bool UseAnimation;
    [SerializeField] Animator Animation;
    [Tooltip("Note - you will need two triggers, both ending with On and Off (e.g. DoorOff)")]
    [SerializeField] string AnimatorTrigger;
    [SerializeField] bool HandOffScriptControl = false;
    [SerializeField] GameObject HealthKit;

	public void TurnOff()
    {
        if (UseAnimation)
        {
            Animation.SetTrigger(AnimatorTrigger+"On");
        }
        if (HandOffScriptControl)
        {
            HealthKit.GetComponent<HealthKitScript>().Heal();
        }
        else gameObject.SetActive(false);

    }

    public void TurnOn()
    {
        if (UseAnimation)
        {
            Animation.SetTrigger(AnimatorTrigger + "Off");
        }
        else gameObject.SetActive(true);
    }
}
