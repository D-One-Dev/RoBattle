using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, length;
    [SerializeField] private float speed;
    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().bounds.size.x);
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        QualitySettings.vSyncCount = 1;
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(speed * -0.05f, 0f, 0f);
        if (transform.position.x <= -(GetComponent<SpriteRenderer>().bounds.size.x))
        {
            transform.position = new Vector3(startPos, 0f, 0f);
        }
    }
}
