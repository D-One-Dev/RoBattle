using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextController : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private int StringNumber;
    [SerializeField] private GameObject background;
    void FixedUpdate()
    {
        if (background.GetComponent<MenuController>().menuString == StringNumber - 1)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time, 1));
        }
        else txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 255f);
    }
}
