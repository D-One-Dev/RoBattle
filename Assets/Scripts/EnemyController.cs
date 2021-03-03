using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private GameObject platform;
    private float speed;
    private float direction;
    private float endPos;
    private bool coll = false;
    void Start()
    {
        speed = 5;
        direction = 1;
    }
    void Update()
    {
        if (coll) Move();    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            platform = collision.gameObject;
            coll = true;
        }
    }
    private void Move()
    {
        endPos = (platform.transform.position.x + direction * (platform.transform.localScale.x / 2));
        if (speed > 0 && endPos <= transform.position.x)
        {
            speed = -speed;
            direction = -1;
        }
        else if (speed < 0 && endPos >= transform.position.x)
        {
            speed = -speed;
            direction = 1;
        }
        rb.velocity = new Vector2(speed, 0f);
    }
}
