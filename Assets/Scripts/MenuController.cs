using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainText, settingsText, controlsText, volumeText, volumeValueText, creditsText;
    [SerializeField] private int menuStringsCount, settingsStringCount, controlsStringCount, creditsStringCount, volumeStringCount;
    [SerializeField] private AudioSource music;
    private PlayerInput PI;
    private int menuList = 0;
    private float volume;
    public int menuString = 0;
    private void Awake()
    {
        PI = new PlayerInput();
        PI.Player.Use.performed += context => Use();
        PI.Player.MenuUp.performed += context => MenuUp();
        PI.Player.MenuDown.performed += context => MenuDown();
        volume = PlayerPrefs.GetFloat("Volume");
    }
    private void OnEnable()
    {PI.Enable();}
    private void OnDisable()
    {PI.Disable();}
    private void Use()
    {
        if (menuList == 0)
        {
            if (menuString == 0)
            {
                SceneManager.LoadScene(sceneName: "Level_0");
            }
            else if (menuString == 1)
            {
                mainText.SetActive(false);
                controlsText.SetActive(true);
                menuList = 2;
                menuString = 0;
            }
            else if (menuString == 2)
            {
                mainText.SetActive(false);
                settingsText.SetActive(true);
                menuList = 1;
                menuString = 0;
            }
            else if (menuString == 3)
            {
                Application.Quit();
            }
        }

        else if (menuList == 1)
        {
            if (menuString == 0)
            {
                settingsText.SetActive(false);
                volumeText.SetActive(true);
                menuList = 3;
                menuString = 0;
                volumeValueText.GetComponent<Text>().text = volume.ToString();
            }
            else if (menuString == 1)
            {
                int language = PlayerPrefs.GetInt("Language");
                if (language == 0) PlayerPrefs.SetInt("Language", 1);
                else PlayerPrefs.SetInt("Language", 0);
            }
            else if (menuString == 2)
            {
                settingsText.SetActive(false);
                creditsText.SetActive(true);
                menuList = 4;
                menuString = 0;
            }
            else if (menuString == 3)
            {
                settingsText.SetActive(false);
                mainText.SetActive(true);
                menuList = 0;
                menuString = 0;
            }
        }

        else if (menuList == 2)
        {
            if (menuString == 0)
            {
                controlsText.SetActive(false);
                mainText.SetActive(true);
                menuList = 0;
                menuString = 0;
            }
        }

        else if (menuList == 3)
        {
            if (menuString == 0)
            {
                if (volume < 10)
                {
                    volume++;
                    PlayerPrefs.SetFloat("Volume", volume);
                    volumeValueText.GetComponent<Text>().text = volume.ToString();
                    music.volume = PlayerPrefs.GetFloat("Volume") / 10;
                }
            }
            else if (menuString == 1)
            {
                if (volume > 0)
                {
                    volume--;
                    PlayerPrefs.SetFloat("Volume", volume);
                    volumeValueText.GetComponent<Text>().text = volume.ToString();
                    music.volume = PlayerPrefs.GetFloat("Volume") / 10;
                }
            }
            else if (menuString == 2)
            {
                volumeText.SetActive(false);
                settingsText.SetActive(true);
                menuList = 1;
                menuString = 0;
            }
        }
        else if (menuList == 4)
        {
            if (menuString == 0)
            {
                creditsText.SetActive(false);
                settingsText.SetActive(true);
                menuList = 1;
                menuString = 0;
            }
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
        if (menuList == 0)
        {
            if (menuString < menuStringsCount - 1)
            {
                menuString++;
            }
        }
        else if (menuList == 1)
        {
            if (menuString < settingsStringCount - 1)
            {
                menuString++;
            }
        }
        else if (menuList == 2)
        {
            if (menuString < controlsStringCount - 1)
            {
                menuString++;
            }
        }
        else if (menuList == 3)
        {
            if (menuString < volumeStringCount - 1)
            {
                menuString++;
            }
        }
        else if (menuList == 4)
        {
            if (menuString < creditsStringCount - 1)
            {
                menuString++;
            }
        }
    }
}
