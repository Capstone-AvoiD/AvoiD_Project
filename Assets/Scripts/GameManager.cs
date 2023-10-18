using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton object setting.
    private static GameManager _instance;

    // 외부에서 GameManager 클래스를 instance로 참조 가능
    public static GameManager instance
    {
        get
        {
            if(_instance == null) _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "MiniGameScene")
            {
                SceneManager.LoadScene("TitleScene");
            }
            else if(SceneManager.GetActiveScene().name == "Platformer_Scene")
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    public void MiniGameScene()
    {
        SceneManager.LoadScene("MiniGameScene");
    }

    public void PlatformerScene()
    {
        SceneManager.LoadScene("Platformer_Scene");
    }
    
    public void GameExit()
    {
        // 전처리기 지시문 이용
        #if UNITY_EDITOR_WIN
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
