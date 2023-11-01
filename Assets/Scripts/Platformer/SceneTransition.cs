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

    private void OnTriggerEnter2D(Collider2D collision)  //player�� Goal�� �����ϴ� ���
    {
        if (collision.gameObject.name == "player")
        {
            Invoke("LoadMiniGameScene", 2.0f);  //2�� ��� �� �̴ϰ��Ӿ����� ��ȯ
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)  //player�� �浹�� ���� ���
    {
        if (collision.gameObject.name == "player")
        {
            CancelInvoke("LoadMiniGameScene");
        }
    }

    private void LoadMiniGameScene()    //�̴ϰ��Ӿ����� ��ȯ
    {
        SceneManager.LoadScene("MiniGameScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
