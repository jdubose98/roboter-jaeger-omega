using UnityEngine;
using System.Collections;

public class GunMaster : MonoBehaviour {

    [SerializeField] GameObject Weapon1;
    [SerializeField] GameObject Weapon2;
    [SerializeField]
    GameObject MeleeWeapon;

    // Use this for initialization
    void Start()
    {
        if (Weapon1.activeSelf == false) {
        Weapon1.SetActive(true); }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Weapon1.SetActive(true);
            Weapon1.GetComponent<GunController>().enabled = true;
            Weapon1.GetComponent<GunController>().Equip();

            Weapon2.SetActive(false);
            Weapon2.GetComponent<GunController>().enabled = false;

            MeleeWeapon.SetActive(false);
            MeleeWeapon.GetComponent<MeleeController>().enabled = false;

            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Weapon1.SetActive(false);
            Weapon1.GetComponent<GunController>().enabled = false;

            Weapon2.SetActive(true);
            Weapon2.GetComponent<GunController>().enabled = true;
            Weapon2.GetComponent<GunController>().Equip();

            MeleeWeapon.SetActive(false);
            MeleeWeapon.GetComponent<MeleeController>().enabled = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Weapon1.SetActive(false);
            Weapon1.GetComponent<GunController>().enabled = false;

            Weapon2.SetActive(false);
            Weapon2.GetComponent<GunController>().enabled = false;

            MeleeWeapon.SetActive(true);
            MeleeWeapon.GetComponent<MeleeController>().enabled = true;
            MeleeWeapon.GetComponent<MeleeController>().Equip();

        }
    }
}
