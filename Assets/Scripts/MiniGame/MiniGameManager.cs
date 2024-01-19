using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private MiniGamePlayer miniGamePlayer;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject retryMenu;
    [SerializeField] private GameObject clearMenu;
    [SerializeField] private TextMeshProUGUI timerText;

    private MiniGameFade fade;

    private bool isState = false;
    private bool isPause = false;

    private int time = 20;
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

    private bool isClear = false;
    private bool IsClear
    {
        get { return isClear; }
        set
        {
            isClear = value;

            if(isClear)
            {
                gameManager.ChangeGameState();
                clearMenu.SetActive(true);
            }
        }
    }

    private void Awake()
    {
        if(gameManager == null) gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        fade = gameObject.GetComponent<MiniGameFade>();
    }

    private void Start()
    {
        StartCoroutine(fade.FadeOut());
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

        if(time < 0 && !isClear)
        {
            BoxCollider2D player = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();

            player.isTrigger = true;

            IsClear = true;
        }
    }

    public void ClickReturnBtn()
    {
        ShowPauseMenu();
    }

    public void ClickNextBtn()
    {
        if(gameManager.CheckState() == GameManager.GameClearState.Park)
        {
            StartCoroutine(fade.FadeIn("Platformer_LastScene"));
        }
        else
        {
            StartCoroutine(fade.FadeIn("WorldMapScene"));
        }
    }

    public void ClickSettingBtn()
    {
        Debug.Log("Setting Button is clicked");
    }

    public void ClickTitleBtn()
    {
        StartCoroutine(fade.FadeIn("TitleScene"));
    }
}
