using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private PlayerInput PI;
    private void Awake()
    {
        PI = new PlayerInput();
        PI.Player.Start.performed += context => StartGame();
    }
    private void OnEnable()
    {PI.Enable();}
    private void OnDisable()
    {PI.Disable();}
    private void StartGame()
    {
        SceneManager.LoadScene(sceneName: "Level_0");
    }
}
