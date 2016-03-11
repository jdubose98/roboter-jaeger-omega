using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeleeController : MonoBehaviour {

    [SerializeField] Collider Hitbox;

    [SerializeField] int Damage;

    [SerializeField] float SwingTime;

    [SerializeField] Animator WeaponAnimator;

    [SerializeField] string AnimTrigger;
    [SerializeField] AudioClip Trigger1Sound;
    [SerializeField] string AnimTrigger2;
    [SerializeField] AudioClip Trigger2Sound;

    // GUI
    [SerializeField] Text AmmoCounter;
    [SerializeField] Text WeaponName;
    [SerializeField] string NameOfWeapon;
    [SerializeField] Image AmmoFillBar;

    bool CanSwing = true;
    bool powerSwing = false;

    float delayTime;
	
    void Start()
    {
        Hitbox.enabled = false;
        Equip();
    }

	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0) && CanSwing){
            gameObject.GetComponent<AudioSource>().clip = Trigger1Sound;
            delayTime = .1f;
            StartCoroutine(Swing(AnimTrigger));
        }
        if (Input.GetMouseButtonDown(1) && CanSwing)
        {
            powerSwing = true;
            gameObject.GetComponent<AudioSource>().clip = Trigger2Sound;
            delayTime = .25f;
            StartCoroutine(Swing(AnimTrigger2));
        }
    }

    IEnumerator Swing(string usedTrigger)
    {
        CanSwing = false;
        Hitbox.enabled = true;
        gameObject.GetComponent<AudioSource>().PlayDelayed(delayTime);
        WeaponAnimator.SetTrigger(usedTrigger);
        yield return new WaitForSeconds(SwingTime);
        Hitbox.enabled = false;
        CanSwing = true;
    }

    public void Equip()
    {
        WeaponName.text = NameOfWeapon;
        AmmoCounter.text = " - ";
        AmmoFillBar.fillAmount = 1.0f;
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            int newDamage = 0;
            if (powerSwing) { newDamage = Damage * 2; powerSwing = false; } else {newDamage = Damage;}
            Debug.Log(newDamage);
            hit.gameObject.GetComponent<EnemyHealth>().TakeDamage(newDamage);
        }
    }
}
