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

    private bool isState = false;

    private bool isGameOver
    {
        get
        {
            isGameOver = isState;
            return isGameOver;
        }
        set
        {
            isState = value;

            if(isState)
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