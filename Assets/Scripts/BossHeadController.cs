using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeadController : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;
    [SerializeField] private float smooth;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite idle, damage;
    private Vector3 randomMove = Vector3.zero;
    private int randomPlatform = 1, hp = 5;
    private float timer, posX = 0;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (mainCam.transform.position.x >= 32f)
        {
            Vector3 smoothMove = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 6.5f, transform.position.z), smooth * Time.fixedDeltaTime);
            transform.position = smoothMove;
        }
        if (transform.position.y <= 6.51f)
        {
            timer += Time.fixedDeltaTime;
        }
        if (timer >= 3f)
        {
            int random = Random.Range(0, 3);
            while (random == randomPlatform)
            {
                random = Random.Range(0, 3);
            }
            randomPlatform = random;
            timer = 0f;
            if (randomPlatform == 0)
            {
                posX = 26f;
            }
            else if (randomPlatform == 1)
            {
                posX = 33f;
            }
            else if (randomPlatform == 2)
            {
                posX = 40f;
            }
            
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
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            sr.sprite = idle;
        }
    }
}
