using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    private MiniGamePlayer miniGamePlayer;
    
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject retryMenu;

    private bool isState = false;
    private bool isPause = false;

    private bool isGameOver
    {
        get
        {
            return isState;
        }
        set
        {
            isState = value;

            if(isState)
            {
                ShowGameOverMenu();
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

        if(!isGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
    }

    private void ShowPauseMenu()
    {
        isPause = !isPause;
        pauseMenu.SetActive(isPause);
        Time.timeScale = isPause ? 0.0f : 1.0f;
    }

    private void ShowGameOverMenu()
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

    public void ClickReturnBtn()
    {
        ShowPauseMenu();
    }

    public void ClickSettingBtn()
    {
        Debug.Log("Setting Button is clicked");
    }

    public void ClickTitleBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
