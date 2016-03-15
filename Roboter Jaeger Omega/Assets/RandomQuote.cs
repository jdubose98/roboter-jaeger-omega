using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomQuote : MonoBehaviour {

    [SerializeField] string[] m_RandomQuotes;
    [SerializeField] Text m_Text;

	public void RandomizeText()
    {
        int n = Random.Range(1, m_RandomQuotes.Length);
        m_Text.text = m_RandomQuotes[n];
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            RandomizeText();
        }
    }
}
