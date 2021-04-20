using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private string TextEng, TextRus;
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            txt.text = TextEng;
        }
        else if (PlayerPrefs.GetInt("Language") == 1)
        {
            txt.text = TextRus;
        }
    }
}
