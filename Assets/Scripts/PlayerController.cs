using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask lm;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject hearts;
    [SerializeField] private Text deathTxt;
    public bool isDead = false;
    private PlayerInput PI;
    private int HP = 3;
    private void Awake()
    {
        PI = new PlayerInput();
        PI.Player.Jump.performed += context => Jump();
        PI.Player.Menu.performed += context => Menu();
        PI.Player.Start.performed += context => Restart();
    }
    private void OnEnable()
    {PI.Enable();}
    private void OnDisable()
    {PI.Disable();}
    void Update()
    {
        float direction = PI.Player.Move.ReadValue<float>();
        if (!isDead) Move(direction);
        else rb.velocity = new Vector2(0f, 0f);
    }
    private bool IsGrounded()
    {
        RaycastHit2D rh = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, lm);
        return rh.collider != null;
    }
    private void Jump() 
    {
        if (IsGrounded()) rb.velocity = Vector2.up * jumpForce;
    }
    private void Move(float speed)
    {
        if(speed > 0.5f) rb.velocity = new Vector2(5f, rb.velocity.y);
        else if (speed < -0.5f) rb.velocity = new Vector2(-5f, rb.velocity.y);
        else rb.velocity = new Vector2(0, rb.velocity.y);
    }
    private void Menu()
    {
        SceneManager.LoadScene(sceneName: "TitleScreen");
    }
    private void Restart()
    {
        if (isDead) SceneManager.LoadScene(sceneName: "Level_0");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && HP > 0)
        {
            HP--;
            hearts.GetComponent<HPController>().HPUpdate(HP);
        }
        if (HP == 0)
        {
            rb.gravityScale = 0f;
            bc.enabled = false;
            deathTxt.GetComponent<DeathTextComtroller>().Death();
        }
    }
}
