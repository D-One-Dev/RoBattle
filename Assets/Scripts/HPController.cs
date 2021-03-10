using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer HP_1, HP_2, HP_3;
    [SerializeField] private Sprite HP_On, HP_Off;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void HPUpdate(int hp)
    {
        if (hp == 3)
        {
            HP_1.sprite = HP_On;
            HP_2.sprite = HP_On;
            HP_3.sprite = HP_On;
        }
        else if (hp == 2)
        {
            HP_1.sprite = HP_On;
            HP_2.sprite = HP_On;
            HP_3.sprite = HP_Off;
        }
        else if (hp == 1)
        {
            HP_1.sprite = HP_On;
            HP_2.sprite = HP_Off;
            HP_3.sprite = HP_Off;
        }
        else
        {
            HP_1.sprite = HP_Off;
            HP_2.sprite = HP_Off;
            HP_3.sprite = HP_Off;
        }
    }
}
