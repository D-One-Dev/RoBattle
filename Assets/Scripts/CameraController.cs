using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smooth;
    private void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        if (transform.position.x >= 25f)
        {
            Vector3 smoothPos = Vector3.Lerp(transform.position, new Vector3(33f, transform.position.y, transform.position.z), smooth * Time.fixedDeltaTime);
            transform.position = smoothPos;
        }
        else
        {
            Vector3 playerPos = player.position;
            Vector3 smoothPos = Vector3.Lerp(transform.position, playerPos, smooth * Time.fixedDeltaTime);
            transform.position = new Vector3(smoothPos.x, 0f, -10f);
        }
    }
}
