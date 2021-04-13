using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeadController : MonoBehaviour
{
    [SerializeField] private GameObject mainCam, bossAttack;
    [SerializeField] private float smooth, headMoveTime, attackTime;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite idle, damage;
    [SerializeField] private AudioClip gameMusic, bossMusic;
    [SerializeField] private AudioSource music;
    private Vector3 randomMove = Vector3.zero;
    private int randomPlatform = 1, hp = 5;
    private float timer, attackTimer, posX = 0;
    private bool isMusicOn = false;
    void FixedUpdate()
    {
        if (mainCam.transform.position.x >= 32f)
        {
            if (!isMusicOn)
            {
                music.Stop();
                music.clip = bossMusic;
                music.Play();
                isMusicOn = true;
            }
            Vector3 smoothMove = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 6.5f, transform.position.z), smooth * Time.fixedDeltaTime);
            transform.position = smoothMove;
        }
        if (transform.position.y <= 6.51f)
        {
            timer += Time.fixedDeltaTime;
            attackTimer += Time.fixedDeltaTime;
        }
        if (timer >= headMoveTime)
        {
            int random = Random.Range(0, 3);
            while (random == randomPlatform) random = Random.Range(0, 3);
            randomPlatform = random;
            timer = 0f;
            if (randomPlatform == 0) posX = 26f;
            else if (randomPlatform == 1) posX = 33f;
            else if (randomPlatform == 2) posX = 40f;
        }
        if (attackTimer >= attackTime)
        {
            bossAttack.GetComponent<BossAttackController>().Attack();
            attackTimer = 0f;
        }
        if (posX != 0)
        {
            randomMove = Vector3.Lerp(transform.position, new Vector3(posX, transform.position.y, transform.position.z), smooth * Time.fixedDeltaTime);
            transform.position = randomMove;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            sr.sprite = damage;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.transform.position = new Vector3(0f, -10f, 0f);
            hp--;
            if (hp == 0)
            {
                Destroy(this.gameObject);
                music.Stop();
                music.clip = gameMusic;
                music.Play();
                isMusicOn = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") sr.sprite = idle;
    }
}
