using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string ChatText = "";
    private GameObject Main;
    private GameObject TextTrigger;
    bool typing;
    string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        Main = GameObject.Find("Main");
        TextTrigger = GameObject.Find("TextTrigger");
        TextTrigger.SetActive(false);   //��ȣ�ۿ� �ؽ�Ʈ ��Ȯ��
        typing = true;
    }

    private void OnTriggerStay2D(Collider2D collision)  //player�� npc�� �浹 ���� ���
    {
        if(collision.gameObject.name == "player")
        {
            TextTrigger.SetActive(true);            
            if (Input.GetKey(KeyCode.G)) //GŰ ���� ��ȣ�ۿ�
            {
                if (typing == true) //typing ���� �߰�
                {
                    if(currentSceneName == "Platformer_School")
                    {
                        Main.GetComponent<MainScript>().NPCChatEnter(ChatText);
                        typing = false;
                    }
                    else if (currentSceneName == "Platformer_PlayGround")
                    {
                        Main.GetComponent<PlaygroundMainScript>().NPCChatEnter(ChatText);
                        typing = false;
                    }
                    else if (currentSceneName == "Platformer_Park")
                    {
                        Main.GetComponent<ParkMainScript>().NPCChatEnter(ChatText);
                        typing = false;
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //player�� npc �浹�� ���� ���
    {
        if(collision.gameObject.name == "player")
        {
            switch(SceneManager.GetActiveScene().name)
            {
                case "Platformer_PlayGround":
                    Main.GetComponent<PlaygroundMainScript>().NPCChatExit();
                    break;
                case "Platformer_Park":
                    Main.GetComponent<ParkMainScript>().NPCChatExit();
                    break;
                default:
                    Main.GetComponent<MainScript>().NPCChatExit();
                    break;
            }

            TextTrigger.SetActive(false);
            typing = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(typing);   
    }
}
