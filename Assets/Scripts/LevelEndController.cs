using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndController : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private Outline ol;
    void Start()
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 255);
        ol.effectColor = new Color(ol.effectColor.r, ol.effectColor.g, ol.effectColor.b, 255);
    }
    void FixedUpdate()
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 255);
        ol.effectColor = new Color(ol.effectColor.r, ol.effectColor.g, ol.effectColor.b, 255);
    }
}
