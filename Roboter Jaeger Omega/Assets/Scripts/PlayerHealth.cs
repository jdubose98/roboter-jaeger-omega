using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float Health;
    [SerializeField] float BleedOutTime;

    [SerializeField] Text HealthCounter;
    [SerializeField] Image HealthFillBar;

    [SerializeField]
    PlayerDeathScript KillScript;

    public int PlayerCurrentHealth;

    public bool NotDead = true;

	void Start () {
        PlayerCurrentHealth = (int)Health;
        UpdateUI();
    }


    public void PlayerTakeDamage(int damage)
    {
        if (NotDead) { 
        PlayerCurrentHealth = PlayerCurrentHealth - damage;
        if (PlayerCurrentHealth <= 0 && NotDead)
            {
                NotDead = false;
                KillScript.Die();
            }
        UpdateUI();
        }
    }

    void GoDown() // The player is "knocked down"
    {

    }

    public void UpdateUI()
    {
        HealthCounter.text = "" + PlayerCurrentHealth;
        HealthFillBar.fillAmount = (PlayerCurrentHealth / Health);
    }

}
