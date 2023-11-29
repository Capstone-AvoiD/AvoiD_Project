using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private MiniGamePlayer miniGamePlayer;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject retryMenu;
    [SerializeField] private TextMeshProUGUI timerText;

    private bool isState = false;
    private bool isPause = false;

    private int time = 120;
    private int minute = 0;
    private int second = 0;
    private string zeroSecond = "0";

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

    private void Awake()
    {
        StartCoroutine(SetTimer());
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
        StopCoroutine(SetTimer());
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

    private IEnumerator SetTimer()
    {
        while(time >= 0)
        {
            minute = time / 60;
            second = time % 60;
            zeroSecond =  second < 10 ? "0" : "";
            timerText.text = minute + "<color=black> : </color>" + zeroSecond + second;
            yield return new WaitForSeconds(1.0f);
            time--;
        }
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
