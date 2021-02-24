using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    private bool jump = false;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (!jump)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                jump = true;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneName: "TitleScreen");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jump = false;
        }
    }
}
