using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private BoxCollider2D bc;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        if ((player.transform.position.x + (player.transform.localScale.x) / 2) >= (transform.position.x - (transform.localScale.x) / 2) &&
        (player.transform.position.x - (player.transform.localScale.x) / 2) <= (transform.position.x + (transform.localScale.x) / 2) &&
        (player.transform.position.y - (player.transform.localScale.y)/2) < transform.position.y + (transform.localScale.y)/2)
        {
            bc.enabled = false;
        }
        else
        {
            bc.enabled = true;
        }
    }
}
