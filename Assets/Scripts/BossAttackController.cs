using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    [SerializeField] private float smooth;
    private int platform = -1, stage = 0;
    private float posX;
    private Vector3 move = Vector3.zero;
    void FixedUpdate()
    {
        if (transform.position.x != 0f && stage == 0) stage = 1;
        else if (transform.position.y >= -9.001f && stage == 1) stage = 2;
        else if (transform.position.y >= -2.001f && stage == 2) stage = 3;
        if (stage == 1)
        {
            transform.localScale = new Vector3(2.9f, transform.localScale.y, transform.localScale.z);
            move = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -9f, transform.position.z), smooth * Time.fixedDeltaTime);
            transform.position = move;
        }
        else if (stage == 2)
        {
            transform.localScale = new Vector3(3f, transform.localScale.y, transform.localScale.z);
            move = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -2f, transform.position.z), smooth * Time.fixedDeltaTime);
            transform.position = move;
        }
        else if (stage == 3)
        {
            transform.localScale = new Vector3(2.9f, transform.localScale.y, transform.localScale.z);
            move = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -15f, transform.position.z), smooth * Time.fixedDeltaTime);
            transform.position = move;
        }
    }

    public void Attack()
    {
        int random = Random.Range(0, 3);
        while (random == platform) random = Random.Range(0, 3);
        platform = random;
        if (platform == 0) posX = 26f;
        else if (platform == 1) posX = 33f;
        else if (platform == 2) posX = 40f;
        transform.position = new Vector3(posX, -15f, transform.position.z);
        stage = 0;
    }
}
