using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;
    public TMP_Text ScoreText;
    public GameObject ScorePanel,PausePanel;
    public GameObject GameOverPanel;

    public float RestartTime = 3f;
    private int Health = 3;
    public int Score;
    public bool IsGameOver = false;
    public bool IsGamePaused = true;
    public bool IsGameStarted = false;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
            _instance = this;
            ScoreText = ScorePanel.GetComponentInChildren<TMP_Text>();
    }
    void Start()
    {
        Time.timeScale = 0;
        IsGameStarted = false;
        IsGamePaused = true;
    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = Score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                IsGamePaused = false;
                PausePanel.SetActive(false);
            }
            else
            {
                IsGamePaused = true;
                PausePanel.SetActive(true);
            }

        }

        if(Health == 0)
        {
            IsGameOver = true;
            GameOverPanel.SetActive(true);
            ScorePanel.SetActive(false);
            Invoke("RestartGame", RestartTime);
            
        }
        

        if (IsGamePaused && IsGameStarted)
        {
            Time.timeScale = 0;
            ScorePanel.SetActive(false);

        }
        
        if (!IsGamePaused && IsGameStarted) 
        {
            Time.timeScale = 1;
            ScorePanel.SetActive(true);
        }

    }
    public void TakeDamage()
    {
        Health--;
    }

    public void RestartGame()
    {
        DestroyAllFruits();
        IsGameOver = false;
        GameOverPanel.SetActive(false);
        ScorePanel.SetActive(true);
        Score = 0;
        Health = 3;
        
    }

    void DestroyAllFruits()
    {
        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");
        foreach(GameObject fruit in fruits)
        {
            Destroy(fruit);
        }
    }
   
}
