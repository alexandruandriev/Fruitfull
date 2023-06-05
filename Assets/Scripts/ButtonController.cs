using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonController : MonoBehaviour
{
    // TODO ADD Settings to the game
    [SerializeField]
    private Button StartBtn, SettingsBtn,MuteBtn,BackBtn;
    Animator CamAnim;
    GameObject MainMenu;
    
    public GameObject SettingsMenu,PauseMenu;
    [SerializeField]
    private Settings settings;
    private void Awake()
    {
        CamAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        MainMenu = GameObject.Find("Main Menu");
        
    }

    public void PlayButton()
    {
        CamAnim.SetBool("GameStarted", true);
        MainMenu.SetActive(false);
        GameManager.Instance.IsGamePaused = false;
        GameManager.Instance.IsGameStarted = true;

    }
    public void SettingsButton()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void SettingsBackButton()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
     
    }

    public void PausedBackButton()
    {
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(false);
        GameManager.Instance.IsGamePaused = false;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MuteButton()
    {
        if (settings.MUTE)
        {
            settings.UnMuteGame();
        }
        else
        {
            settings.MuteGame();
        }
        
    }
    
}
