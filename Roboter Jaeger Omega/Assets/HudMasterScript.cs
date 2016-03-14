using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HudMasterScript : MonoBehaviour {

	public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
