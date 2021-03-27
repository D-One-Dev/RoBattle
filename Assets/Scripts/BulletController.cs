using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject player;
    void Start()
    {
        rb.gravityScale = 0f;
    }
    public void spawnBullet()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, 0f);
        rb.velocity = new Vector2(0f, 0f);
        rb.gravityScale = -1f;
    }
}
