using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsSceneController : MonoBehaviour
{
    private PlayerInput PI;
    private void Awake()
    {
        PI = new PlayerInput();
        PI.Player.Use.performed += context => Use();
    }
    private void OnEnable()
    { PI.Enable(); }
    private void OnDisable()
    { PI.Disable(); }
    private void Use()
    {
        SceneManager.LoadScene(sceneName: "TitleScreen");
    }
}
