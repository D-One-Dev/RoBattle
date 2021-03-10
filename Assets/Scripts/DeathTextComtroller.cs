using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTextComtroller : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private Outline OL;
    [SerializeField] private GameObject player;
    private bool enable = false;
    private float alpha;
    void Start()
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0f);
        OL.effectColor = new Color(OL.effectColor.r, OL.effectColor.g, OL.effectColor.b, 0f);
    }
    void FixedUpdate()
    {
        if (enable)
        {
            player.GetComponent<PlayerController>().isDead = true;
            if (alpha < 1)
            {
                alpha += Time.fixedDeltaTime;
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, alpha);
                OL.effectColor = new Color(OL.effectColor.r, OL.effectColor.g, OL.effectColor.b, alpha);
            }
        }
    }
    public void Death()
    {
        enable = true;
    }
}
