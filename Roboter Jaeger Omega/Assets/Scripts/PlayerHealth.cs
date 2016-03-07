using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] float Health;
    [SerializeField] float BleedOutTime;

    [SerializeField] Text HealthCounter;
    [SerializeField] Image HealthFillBar;

    public int PlayerCurrentHealth;

	void Start () {
        PlayerCurrentHealth = (int)Health;
        UpdateUI();
    }


    public void PlayerTakeDamage(int damage)
    {
        PlayerCurrentHealth -= damage;
        UpdateUI();
    }

    void GoDown() // The player is "knocked down"
    {

    }

    void UpdateUI()
    {
        HealthCounter.text = "" + PlayerCurrentHealth;
        HealthFillBar.fillAmount = (PlayerCurrentHealth / Health);
    }
}
