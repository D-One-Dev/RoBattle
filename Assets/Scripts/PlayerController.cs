using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask lm;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private float jumpForce;
    private PlayerInput PI;
    private void Awake()
    {
        PI = new PlayerInput();
        PI.Player.Jump.performed += context => Jump();
        PI.Player.Menu.performed += context => Menu();
    }
    private void OnEnable()
    {PI.Enable();}
    private void OnDisable()
    {PI.Disable();}
    void Update()
    {
        float direction = PI.Player.Move.ReadValue<float>();
        Move(direction); 
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
}
