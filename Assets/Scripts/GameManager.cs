using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
