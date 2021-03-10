using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextController : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private Outline OL;
    private float a;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time,1));
    }
}
