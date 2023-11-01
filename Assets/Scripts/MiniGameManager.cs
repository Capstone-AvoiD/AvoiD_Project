using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    private MiniGamePlayer miniGamePlayer;
    
    [SerializeField]
    private GameObject retryMenu;

    private bool isGameOver
    {
        get
        {
            return false;
        }
        set
        {
            isGameOver = value;

            if(isGameOver)
            {
                ShowGameMenu();
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(miniGamePlayer.isFailure)
        {
            SetGameOver();
        }
    }

    private void ShowGameMenu()
    {
        retryMenu.SetActive(true);
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    private void SetGameOver()
    {
        Time.timeScale = 0.0f;
        isGameOver = true;
    }
}
