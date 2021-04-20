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
    [SerializeField] private GameObject hearts, bullet, attackPoint;
    [SerializeField] private Text deathTxt, fireTxt;
    [SerializeField] private Outline fireTxtOL;
    private PlayerInput PI;
    private int HP = 3;
    private float timer, invisTimer;
    public bool isDead = false, isInvis = false, isLevelEnded = false;
    private void Awake()
    {
        PI = new PlayerInput();
        PI.Player.Use.performed += context => Use();
        PI.Player.Menu.performed += context => Menu();
        PI.Player.Fire.performed += context => Attack();
    }
    private void OnEnable()
    {PI.Enable();}
    private void OnDisable()
    {PI.Disable();}
    void FixedUpdate()
    {
        float direction = PI.Player.Move.ReadValue<float>();
        if (!isDead) Move(direction);
        else rb.velocity = new Vector2(0f, 0f);
        if (timer > 0f)
        {
            timer -= Time.fixedDeltaTime;
            fireTxt.color = new Color(255f, 255f, 255f, 0f);
            fireTxtOL.effectColor = new Color(0f, 0f, 0f, 0f);
        }
        if (invisTimer > 0f)
        {
            invisTimer -= Time.fixedDeltaTime;
            isInvis = true;
        }
        else isInvis = false;
    }
    private bool IsGrounded()
    {
        RaycastHit2D rh = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, lm);
        return rh.collider != null;
    }
    private void Use() 
    {
        if (isDead) SceneManager.LoadScene(sceneName: "Level_0");
        else if (isLevelEnded) SceneManager.LoadScene(sceneName: "TitleScreen");
        else
        {
            if (IsGrounded()) rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void Move(float speed)
    {
        if (speed > 0.5f && !isLevelEnded)
        {
            rb.velocity = new Vector2(5f, rb.velocity.y);
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        else if (speed < -0.5f && !isLevelEnded) 
        {
            rb.velocity = new Vector2(-5f, rb.velocity.y);
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
        else rb.velocity = new Vector2(0, rb.velocity.y);
    }
    private void Menu()
    {
        SceneManager.LoadScene(sceneName: "TitleScreen");
    }
    private void Attack()
    {
        if (!isDead && !isLevelEnded)
        {
            if (fireTxt.color.a == 255f && timer <= 0f)
            {
                bullet.GetComponent<BulletController>().spawnBullet();
                timer = 2f;
            }
            else
            {
                GetComponent<PlayerCombat>().Attack();
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AttackPlatform" && timer <= 0f)
        {
            fireTxt.transform.position = new Vector3(transform.position.x, fireTxt.transform.position.y, fireTxt.transform.position.z);
            fireTxt.color = new Color(255f, 255f, 255f, 255f);
            fireTxtOL.effectColor = new Color(0f, 0f, 0f, 255f);
        }


        if (collision.gameObject.tag == "Enemy" && HP > 0 && isInvis == false)
        {
            HP--;
            hearts.GetComponent<HPController>().HPUpdate(HP);
            invisTimer = 2f;
        }
        if (HP == 0)
        {
            isDead = true;
            rb.gravityScale = 0f;
            bc.enabled = false;
            deathTxt.GetComponent<DeathTextController>().Death();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AttackPlatform")
        {
            fireTxt.color = new Color(255f, 255f, 255f, 0f);
            fireTxtOL.effectColor = new Color(0f, 0f, 0f, 0f);
        }
    }
}
