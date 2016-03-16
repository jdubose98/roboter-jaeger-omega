using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScr : MonoBehaviour {

    [SerializeField] Text TimeText;

    // Use this for initialization
    void FixedUpdate() {
        int minutes = (int)Time.time / 60;
        int hours = minutes / 60; // I don't expect anyone to play this for hours on end...

        TimeText.text = (hours + ":" + minutes + ":" + Mathf.Floor((Time.time % 60)));
    }
}
