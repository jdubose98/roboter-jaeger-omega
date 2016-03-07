using UnityEngine;
using System.Collections;
using UnityEngine.Audio;


public class MOREGUNS : MonoBehaviour
{

    [SerializeField]
    GameObject Weapon1;
    [SerializeField]
    GameObject Weapon2;
    [SerializeField]
    GameObject Weapon3;
    [SerializeField]
    GameObject Weapon4;
    [SerializeField]
    GameObject Weapon5;
    [SerializeField]
    GameObject Weapon6;

    [SerializeField]
    AudioMixer Mixer;

    // Use this for initialization
    void Start()
    {
        if (Weapon1.activeSelf == false)
        {
            Weapon1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Weapon1.SetActive(true);
            Weapon1.GetComponent<GunController>().enabled = true;
            Weapon1.GetComponent<GunController>().Equip();

            Weapon2.SetActive(false);
            Weapon2.GetComponent<GunController>().enabled = false;
            Weapon3.SetActive(false);
            Weapon3.GetComponent<GunController>().enabled = false;
            Weapon4.SetActive(false);
            Weapon4.GetComponent<GunController>().enabled = false;
            Weapon5.SetActive(false);
            Weapon5.GetComponent<GunController>().enabled = false;
            Weapon6.SetActive(false);
            Weapon6.GetComponent<GunController>().enabled = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Weapon1.SetActive(false);
            Weapon1.GetComponent<GunController>().enabled = false;
            Weapon3.SetActive(false);
            Weapon3.GetComponent<GunController>().enabled = false;
            Weapon4.SetActive(false);
            Weapon4.GetComponent<GunController>().enabled = false;
            Weapon5.SetActive(false);
            Weapon5.GetComponent<GunController>().enabled = false;
            Weapon6.SetActive(false);
            Weapon6.GetComponent<GunController>().enabled = false;

            Weapon2.SetActive(true);
            Weapon2.GetComponent<GunController>().enabled = true;
            Weapon2.GetComponent<GunController>().Equip();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Weapon1.SetActive(false);
            Weapon1.GetComponent<GunController>().enabled = false;
            Weapon2.SetActive(false);
            Weapon2.GetComponent<GunController>().enabled = false;
            Weapon4.SetActive(false);
            Weapon4.GetComponent<GunController>().enabled = false;
            Weapon5.SetActive(false);
            Weapon5.GetComponent<GunController>().enabled = false;
            Weapon6.SetActive(false);
            Weapon6.GetComponent<GunController>().enabled = false;

            Weapon3.SetActive(true);
            Weapon3.GetComponent<GunController>().enabled = true;
            Weapon3.GetComponent<GunController>().Equip();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Weapon1.SetActive(false);
            Weapon1.GetComponent<GunController>().enabled = false;
            Weapon3.SetActive(false);
            Weapon3.GetComponent<GunController>().enabled = false;
            Weapon2.SetActive(false);
            Weapon2.GetComponent<GunController>().enabled = false;
            Weapon5.SetActive(false);
            Weapon5.GetComponent<GunController>().enabled = false;
            Weapon6.SetActive(false);
            Weapon6.GetComponent<GunController>().enabled = false;

            Weapon4.SetActive(true);
            Weapon4.GetComponent<GunController>().enabled = true;
            Weapon4.GetComponent<GunController>().Equip();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Weapon1.SetActive(false);
            Weapon1.GetComponent<GunController>().enabled = false;
            Weapon3.SetActive(false);
            Weapon3.GetComponent<GunController>().enabled = false;
            Weapon4.SetActive(false);
            Weapon4.GetComponent<GunController>().enabled = false;
            Weapon2.SetActive(false);
            Weapon2.GetComponent<GunController>().enabled = false;
            Weapon6.SetActive(false);
            Weapon6.GetComponent<GunController>().enabled = false;

            Weapon5.SetActive(true);
            Weapon5.GetComponent<GunController>().enabled = true;
            Weapon5.GetComponent<GunController>().Equip();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Weapon1.SetActive(false);
            Weapon1.GetComponent<GunController>().enabled = false;
            Weapon3.SetActive(false);
            Weapon3.GetComponent<GunController>().enabled = false;
            Weapon4.SetActive(false);
            Weapon4.GetComponent<GunController>().enabled = false;
            Weapon5.SetActive(false);
            Weapon5.GetComponent<GunController>().enabled = false;
            Weapon2.SetActive(false);
            Weapon2.GetComponent<GunController>().enabled = false;

            Weapon6.SetActive(true);
            Weapon6.GetComponent<GunController>().enabled = true;
            Weapon6.GetComponent<GunController>().Equip();
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0.25f;
                Mixer.SetFloat("Pitch", .25f);
            }
            else {
                Time.timeScale = 1f;
                Mixer.SetFloat("Pitch", 1f);
            }
        }
    }
}
