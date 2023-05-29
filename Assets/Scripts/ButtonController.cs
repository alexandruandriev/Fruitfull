using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    // TODO ADD Settings to the game
    [SerializeField]
    private Button StartBtn, SettingsBtn;
    Animator CamAnim;
    GameObject MainMenu;
    private void Awake()
    {
        CamAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        MainMenu = GameObject.Find("Main Menu");
    }

    public void StartButton()
    {
        CamAnim.SetBool("GameStarted", true);
        MainMenu.SetActive(false);
        GameManager.Instance.GamePaused = false;
    }
}
