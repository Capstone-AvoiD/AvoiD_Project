using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("GoalPanel");
    }

    private void OnTriggerEnter2D(Collider2D collision)  //player�� Goal�� �����ϴ� ���
    {
        if (collision.gameObject.name == "player")
        {
            Invoke("Fading", 2.0f);  //2�� ��� �� �̴ϰ��Ӿ����� ��ȯ
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)  //player�� �浹�� ���� ���
    {
        if (collision.gameObject.name == "player")
        {
            CancelInvoke("Fading");
        }
    }

    private void Fading()
    {
        Panel.GetComponent<FadeScript>().Fade();
        Invoke("LoadMiniGameScene", 1.0f);
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
