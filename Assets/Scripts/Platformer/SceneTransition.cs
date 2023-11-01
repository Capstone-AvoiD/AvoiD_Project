using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)  //player와 Goal이 접촉하는 경우
    {
        if (collision.gameObject.name == "player")
        {
            Invoke("LoadMiniGameScene", 2.0f);  //2초 대기 후 미니게임씬으로 전환
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)  //player와 충돌이 끝날 경우
    {
        if (collision.gameObject.name == "player")
        {
            CancelInvoke("LoadMiniGameScene");
        }
    }

    private void LoadMiniGameScene()    //미니게임씬으로 전환
    {
        SceneManager.LoadScene("MiniGameScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
