using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject particles;
    [SerializeField] private float speed;
    private GameObject platform;
    private float direction, endPos, timer;
    private bool coll = false;
    private int currentHealth;
    public SpriteRenderer sr;
    public int maxHealth;
    void Start()
    {
        direction = 1;
        currentHealth = maxHealth;
    }
    void FixedUpdate()
    {
        if (coll) Move();
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
    }
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
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (speed < 0 && endPos >= transform.position.x)
        {
            speed = -speed;
            direction = 1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        rb.velocity = new Vector2(speed, 0f);
    }

    public void TakeDamage(int damage)
    {
        particles.transform.position = transform.position;
        particles.GetComponent<ParticleSystem>().Play();
        timer = 0.1f;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
