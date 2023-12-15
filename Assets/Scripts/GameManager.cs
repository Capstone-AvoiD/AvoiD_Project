using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [HideInInspector] public enum GameClearState { None, School, Ground, Park};
    [HideInInspector] public static GameClearState gameState = GameClearState.None;

    // 외부에서 GameManager 클래스를 instance로 참조 가능 - Singleton Pattern
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
        if(_instance == null)                                                   // GameManager가 존재하지 않을 경우 이 오브젝트를 GameManager로 설정
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))                                    // 임시용 씬 전환 기능 - esc키를 통해 씬 전환
        {
            if(SceneManager.GetActiveScene().name == "Platformer_Scene")
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    public void ChangeGameState()
    {
        gameState++;
    }

    public GameClearState CheckState()
    {
        return gameState;
    }
}
