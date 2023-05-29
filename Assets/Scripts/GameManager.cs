using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;
    public TMP_Text ScoreText;
    public GameObject ScorePanel;
    public GameObject GameOverPanel;

    public float RestartTime = 3f;
    private int Health = 3;
    public int Score;
    public bool GameOver = false;
    public bool GamePaused = true;

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
        GamePaused = true;
    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = Score.ToString();

        
        if(Health == 0)
        {
            GameOver = true;
            GameOverPanel.SetActive(true);
            ScorePanel.SetActive(false);
            Invoke("RestartGame", RestartTime);
            
        }
        

        if (GamePaused)
        {
            Time.timeScale = 0;
            ScorePanel.SetActive(false);

        }
        else
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
        GameOver = false;
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
