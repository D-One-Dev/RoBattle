using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int menuStringsCount;
    private PlayerInput PI;
    public int menuString = 0;
    private void Awake()
    {
        PI = new PlayerInput();
        PI.Player.Use.performed += context => Use();
        PI.Player.MenuUp.performed += context => MenuUp();
        PI.Player.MenuDown.performed += context => MenuDown();
    }
    private void OnEnable()
    {PI.Enable();}
    private void OnDisable()
    {PI.Disable();}
    private void Use()
    {

        if (menuString == 0)
        {
            SceneManager.LoadScene(sceneName: "Level_0");
        }
        else if (menuString == 1)
        {
            SceneManager.LoadScene(sceneName: "Controls");
        }
        else if (menuString == 2)
        {
            int language = PlayerPrefs.GetInt("Language");
            if (language == 0) PlayerPrefs.SetInt("Language", 1);
            else PlayerPrefs.SetInt("Language", 0);
        }
        else if (menuString == 3)
        {
            Application.Quit();
        }
    }
    private void MenuUp()
    {
        if (menuString > 0)
        {
            menuString--;
        }
    }
    private void MenuDown()
    {
        if (menuString < menuStringsCount - 1)
        {
            menuString++;
        }
    }
}
