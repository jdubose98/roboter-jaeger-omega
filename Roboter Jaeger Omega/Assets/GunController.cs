using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

    // Positions
    [Tooltip("Transform for the bullets to come from.")]
    [SerializeField] Transform SourcePosition;

    // Weapon values

    [Tooltip("How long it takes to fire the gun again.")]
    [SerializeField] float TimeBetweenShots;

    [Tooltip("Time to reload the gun.")]
    [SerializeField] float ReloadTime;

    [Tooltip("Maximum ammo within the gun.")]
    [SerializeField] int ClipSize;

    [Tooltip("Maximum damage the gun deals.")]
    [SerializeField] int MaxDamage;

    [Tooltip("Falloff \"rate\" over distance")]
    [SerializeField] float DamageFalloffRate;

    [Tooltip("Spread of the weapon")]
    [SerializeField] float GunSpread;

    // Modes
    [Tooltip("Is the gun automatic?")]
    [SerializeField] bool Automatic = false;

    [Tooltip("Does this gun shoot multiple projectiles at once?")]
    [SerializeField] bool Shotgun = false;

    [Tooltip("Does this weapon shoot exploding rounds?")]
    [SerializeField] bool Explosive = false;

    // Array
    [Tooltip("Offset values for the gun.")]
    [SerializeField] float[] WeaponOffset;

    // GUI
    [SerializeField] Text AmmoCounter;
    [SerializeField] Text GunName;
    [SerializeField] string NameOfGun;

    //Other
    [SerializeField]
    Animator WeaponAnimator;

    [SerializeField] string ReloadTrigger;

    // No touchy
    Transform Offset;
    public float AmmoInGun; // made public for other things to see ammo count
    float lastTime;
    bool canFire = true;
    bool canReload = true;

    ParticleSystem particles;

    [SerializeField] Image AmmoFillBar;

    // Use this for initialization
    void Start () {
        AmmoInGun = ClipSize;
        lastTime = Time.time;
        //gameObject.transform.position = new Vector3(WeaponOffset[0], WeaponOffset[1], WeaponOffset[2]);
        particles = SourcePosition.GetComponentInChildren<ParticleSystem>();
        Equip();
    }
	
	// Update is called once per frame
	void Update () {
        if (Automatic && Input.GetMouseButton(0))
        {
            if ((lastTime + TimeBetweenShots < Time.time) && canFire) {
                Fire();
                AmmoInGun = AmmoInGun - 1;
                AmmoCounter.text = AmmoInGun + " / " + ClipSize;
                AmmoFillBar.fillAmount = (AmmoInGun / ClipSize) ;
                
                if (AmmoInGun == 0)
                {
                    canFire = false;
                    canReload = true;
                }
                
                lastTime = Time.time;
            }
        }
        if (!Automatic && Input.GetMouseButtonDown(0) && canFire && (lastTime + TimeBetweenShots < Time.time))
        {
            Fire();
            AmmoInGun = AmmoInGun - 1;
            AmmoCounter.text = AmmoInGun + " / " + ClipSize;
            AmmoFillBar.fillAmount = AmmoInGun/ClipSize;
            if (AmmoInGun == 0)
            {
                canFire = false;
                canReload = true;
            }
            lastTime = Time.time;
            Debug.Log(AmmoInGun/ClipSize);
        }


        if (Input.GetKeyDown(KeyCode.R) && canReload)
        {
            if (AmmoInGun != ClipSize)
            {
                // play reload sound
                Debug.Log("Reloading");
                canReload = false;
                StartCoroutine(Reload());
            } 
        }
	}

    void Fire()
    {
        if (Shotgun)
        {
            WeaponAnimator.SetTrigger("PumpShotgun");
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
            {
            SourcePosition.GetComponent<LineRenderer>().enabled = true;
            SourcePosition.GetComponent<LineRenderer>().SetPosition(0, SourcePosition.transform.position);
            SourcePosition.GetComponent<LineRenderer>().SetPosition(1, hit.point);
            StartCoroutine(RendererDisable());
        }

        gameObject.GetComponent<AudioSource>().Play();

        if (!particles.isPlaying)
        {
            particles.Play();
        }
        else if (particles.isPlaying)
        {
            particles.Stop();
            particles.Play();
        }
    }

    IEnumerator Reload()
    {
        WeaponAnimator.SetTrigger(ReloadTrigger);
        yield return new WaitForSeconds(ReloadTime);
        canFire = true;
        canReload = true;
        AmmoInGun = ClipSize;
        AmmoCounter.text = AmmoInGun + " / " + ClipSize;
        AmmoFillBar.fillAmount = AmmoInGun/ClipSize;
        gameObject.transform.Rotate(new Vector3(0, 0, -30));
        Debug.Log("Reloaded");
    }

    public void Equip()
    {
        GunName.text = NameOfGun;
        AmmoCounter.text = AmmoInGun + " / " + ClipSize;
        AmmoFillBar.fillAmount = AmmoInGun/ClipSize;
    }

    IEnumerator RendererDisable()
    {
        yield return new WaitForSeconds(.03f);
        SourcePosition.GetComponent<LineRenderer>().enabled = false;
    }


}
