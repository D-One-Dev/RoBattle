using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndController : MonoBehaviour
{
    [SerializeField] private Text txt0, txt1, txt2;
    [SerializeField] private Outline ol0, ol1, ol2;
    public bool showEndText, isAnimationEnded;
    void Start()
    {
        txt0.color = new Color(txt0.color.r, txt0.color.g, txt0.color.b, 0);
        ol0.effectColor = new Color(ol0.effectColor.r, ol0.effectColor.g, ol0.effectColor.b, 0);
        txt1.color = new Color(txt1.color.r, txt1.color.g, txt1.color.b, 0);
        ol1.effectColor = new Color(ol1.effectColor.r, ol1.effectColor.g, ol1.effectColor.b, 0);
        txt2.color = new Color(txt2.color.r, txt2.color.g, txt2.color.b, 0);
        ol2.effectColor = new Color(ol2.effectColor.r, ol2.effectColor.g, ol2.effectColor.b, 0);
    }
    void FixedUpdate()
    {
        if (showEndText && txt0.color.a < 1f)
        {
            txt0.color = new Color(txt0.color.r, txt0.color.g, txt0.color.b, txt0.color.a + 1f * Time.fixedDeltaTime);
            ol0.effectColor = new Color(ol0.effectColor.r, ol0.effectColor.g, ol0.effectColor.b, ol0.effectColor.a + 1f * Time.fixedDeltaTime);
            txt1.color = new Color(txt1.color.r, txt1.color.g, txt1.color.b, txt1.color.a + 1f * Time.fixedDeltaTime);
            ol1.effectColor = new Color(ol1.effectColor.r, ol1.effectColor.g, ol1.effectColor.b, ol1.effectColor.a + 1f * Time.fixedDeltaTime);
            txt2.color = new Color(txt2.color.r, txt2.color.g, txt2.color.b, txt2.color.a + 1f * Time.fixedDeltaTime);
            ol2.effectColor = new Color(ol2.effectColor.r, ol2.effectColor.g, ol2.effectColor.b, ol2.effectColor.a + 1f * Time.fixedDeltaTime);
            Debug.Log(txt0.color.a);
        }
        if (txt0.color.a >= 1f) isAnimationEnded = true;
    }
}
